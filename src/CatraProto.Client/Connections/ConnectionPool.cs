/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.ApiManagers;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.MTProto.Auth.AuthKey;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.Updates;
using Serilog;

namespace CatraProto.Client.Connections
{
    internal class ConnectionPool : IAsyncDisposable
    {
        public RouterQueue MessagesQueue { get; }
        private readonly Dictionary<AuthKeyManager, int> _authKeys = new Dictionary<AuthKeyManager, int>();
        private readonly Dictionary<Connection, int> _referenceCounts = new Dictionary<Connection, int>();
        private readonly AsyncLock _asyncLock = new AsyncLock();
        private UpdatesReceiver? _updatesHandler;
        private readonly TelegramClient _client;
        private Connection? _mainConnection;
        private readonly ILogger _logger;

        public ConnectionPool(TelegramClient client, ILogger logger)
        {
            _client = client;
            _logger = logger.ForContext<ConnectionPool>();
            MessagesQueue = new RouterQueue(logger);
        }

        public async Task InitMainConnectionAsync(CancellationToken token)
        {
            var conn = new Connection(_client.ClientSession.Settings.ConnectionSettings.DefaultDatacenter, _client);
            conn.MtProtoState.KeyManager = CreateOrGetKey(conn, _client.ClientSession.Settings.ConnectionSettings.DefaultDatacenter.DcId, out _);
            await conn.MtProtoState.KeyManager.StartAsync();

            await SetAccountConnectionAsync(conn, false);
            await conn.ConnectAsync(token);
        }

        public async Task<ConnectionItem> GetConnectionByDcAsync(int dcId, bool forceNew, bool isMediaPreferred, CancellationToken token)
        {
            ConnectionItem connectionItem;
            ConnectionItem? mainConnectionItem = null;
            _logger.Information("Retrieving config");
            var config = await _client.ConfigManager.GetConfigAsync(token);

            _logger.Verbose("Waiting for lock");
            using (await _asyncLock.LockAsync(token))
            {
                _logger.Verbose("Lock acquired");
                if (_mainConnection is null)
                {
                    throw new InvalidOperationException("InitMainConnection not called");
                }

                if (dcId == -1)
                {
                    dcId = _mainConnection.ConnectionInfo.DcId;
                }

                if (!forceNew && TryFindLocal(dcId, isMediaPreferred, out var connection))
                {
                    _logger.Verbose("Found matching existing connection");
                    return CreateConnectionItem(connection);
                }

                var isTestDc = _client.ClientSession.Settings.ConnectionSettings.DefaultDatacenter.Test;
                var matches = config.DcOptions
                    .Select(x => new Tuple<DcOptionBase, ConnectionInfo>(x, ConnectionInfo.FromDcOption(x, isTestDc)))
                    .Where(x => Matches(x.Item2, dcId, isMediaPreferred))
                    .OrderBy(x => x.Item1.MediaOnly)
                    .Select(x => x.Item2)
                    .ToList();

                if (matches.Count == 0)
                {
                    throw new Exception("Couldn't find matching dcOption");
                }

                var createdConnection = new Connection(matches[0], _client);
                createdConnection.MtProtoState.KeyManager = CreateOrGetKey(createdConnection, dcId, out var justCreated);
                if (justCreated)
                {
                    mainConnectionItem = CreateConnectionItem(_mainConnection);
                    await createdConnection.MtProtoState.KeyManager.StartAsync();
                }

                connectionItem = CreateConnectionItem(createdConnection);
            }

            try
            {
                await connectionItem.Connection.ConnectAsync(token);
                if (mainConnectionItem is not null && _client.LoginManager.GetCurrentState() is LoginState.LoggedIn)
                {
                    await connectionItem.Connection.MtProtoState.KeyManager!.CopyAuthorizationAsync(mainConnectionItem.Connection, token);
                }
            }
            catch (OperationCanceledException)
            {
                await connectionItem.DisposeAsync();
                throw;
            }
            finally
            {
                if (mainConnectionItem is not null)
                {
                    await mainConnectionItem.DisposeAsync();
                }
            }

            return connectionItem;
        }

        private ConnectionItem CreateConnectionItem(Connection connection)
        {
            var connItem = new ConnectionItem(connection, this);
            _referenceCounts.Remove(connection, out var count);
            _referenceCounts.Add(connection, ++count);
            return connItem;
        }

        public void DecreaseReference(Connection connection)
        {
            Task.Run(async () =>
            {
                try
                {
                    TimeSpan? waitTime = null;
                    using (await _asyncLock.LockAsync())
                    {
                        if (_referenceCounts.TryGetValue(connection, out var rCount) && rCount - 1 == 0)
                        {
                            waitTime = TimeSpan.FromMilliseconds(500);
                        }
                    }

                    if (waitTime is not null)
                    {
                        _logger.Information("Waiting for {Ms}ms before closing connection {Connection}", waitTime.Value.TotalMilliseconds, connection);
                        await Task.Delay(waitTime.Value);
                    }

                    await DecreaseReferenceAsync(connection);
                }
                catch (Exception e)
                {
                    _logger.Warning(e, "Exception thrown while disposing connection");
                }
            });
        }

        public async Task DecreaseReferenceAsync(Connection connection)
        {
            using (await _asyncLock.LockAsync())
            {
                int? keyReferences = null;
                var connKeyManager = connection.MtProtoState.KeyManager;

                if (_referenceCounts.Remove(connection, out var rCount))
                {
                    // Connection is not used by any ConnectionItem
                    if (rCount - 1 == 0)
                    {
                        if (_mainConnection == connection)
                        {
                            // main connection must be kept alive even if no one is using it
                            return;
                        }

                        if (connKeyManager is not null && _authKeys.Remove(connKeyManager, out var references))
                        {
                            keyReferences = references - 1;
                            _authKeys.Add(connKeyManager, references - 1);
                        }

                        if (connKeyManager is null || keyReferences is null)
                        {
                            _logger.Information("Disposing connection {Connection} because no one holds a reference to it and its auth key is not part of this pool", connection);
                            await connection.DisposeAsync();
                            return;
                        }

                        if (connKeyManager.Connection == connection && keyReferences > 0)
                        {
                            _logger.Information("Not disposing connection {Connection} because AuthKey {AuthKey} still holds a reference to it", connection, connKeyManager);
                            return;
                        }

                        if (keyReferences == 0)
                        {
                            _logger.Information("Disposing connection {Connection} and auth key {AuthKey}", connection, connKeyManager);
                            _authKeys.Remove(connKeyManager);

                            await connKeyManager.DisposeAsync();
                            if (connKeyManager.Connection != connection)
                            {
                                _logger.Information("Disposing auth key {AuthKey}'s connection {Connection}", connKeyManager, connKeyManager.Connection);
                                await connKeyManager.Connection.DisposeAsync();
                            }

                            await connection.DisposeAsync();
                        }
                        else
                        {
                            _logger.Information("Disposing connection {Connection} because no one holds a reference to it", connection);
                            await connection.DisposeAsync();
                        }
                    }
                    else
                    {
                        _referenceCounts.Add(connection, --rCount);
                    }
                }
            }
        }

        // Only used at first startup, no need to return item
        public async Task<Connection?> GetMainConnectionAsync(CancellationToken cancellationToken)
        {
            using (await _asyncLock.LockAsync(cancellationToken))
            {
                return _mainConnection;
            }
        }

        // Only used at first startup, no need to check if instance changed
        public async Task ConfirmMainAsync(CancellationToken cancellationToken)
        {
            using (await _asyncLock.LockAsync(cancellationToken))
            {
                if (_mainConnection is not null)
                {
                    _mainConnection.ConnectionInfo.Main = true;
                }
            }
        }

        public async Task SetAccountConnectionAsync(Connection connection, bool isConfirmedMain)
        {
            Connection? previousConnection = null;
            using (await _asyncLock.LockAsync())
            {
                if (_mainConnection is not null)
                {
                    _mainConnection.MessagesDispatcher.UpdatesHandler = null;
                    _mainConnection.ConnectionInfo.Main = false;
                }

                connection.MessagesDispatcher.UpdatesHandler = _updatesHandler;
                connection.ConnectionInfo.Main = isConfirmedMain;
                previousConnection = _mainConnection;
                _mainConnection = connection;
            }

            await MessagesQueue.ReplaceConnectionAsync(CreateConnectionItem(connection));
            if (previousConnection is not null)
            {
                _logger.Information("Main connection changed, forcefully fetching updates difference");
                _ = _client.UpdatesReceiver.ForceGetDifferenceAllAsync(false);
            }
        }

        private AuthKeyManager CreateOrGetKey(Connection connection, int dcId, out bool justCreated)
        {
            var (findKey, _) = _authKeys.FirstOrDefault(x => x.Key.DcId == dcId);
            if (findKey is null)
            {
                findKey = new AuthKeyManager(connection, _client.ClientSession, dcId, _logger);
                _authKeys.Add(findKey, 1);
                justCreated = true;
            }
            else
            {
                _authKeys.Remove(findKey, out var oldCount);
                _authKeys.Add(findKey, ++oldCount);
                justCreated = false;
            }

            return findKey!;
        }

        public async Task SetUpdatesHandlerAsync(UpdatesReceiver updatesReceiver)
        {
            using (await _asyncLock.LockAsync())
            {
                _updatesHandler = updatesReceiver;
                if (_mainConnection != null)
                {
                    _mainConnection.MessagesDispatcher.UpdatesHandler = _updatesHandler;
                }
            }
        }

        private bool Matches(ConnectionInfo connectionInfo, int dcId, bool isMediaPreferred)
        {
            //TODO: Proper ipv6 support
            if (connectionInfo.DcId != dcId)
            {
                return false;
            }

            if (connectionInfo.Ipv6 && !_client.ClientSession.Settings.ConnectionSettings.Ipv6Allowed)
            {
                return false;
            }

            if (!connectionInfo.Ipv6 && _client.ClientSession.Settings.ConnectionSettings.Ipv6Only)
            {
                return false;
            }

            if (connectionInfo.MediaOnly && !isMediaPreferred)
            {
                return false;
            }

            if (connectionInfo.TcpoOnly)
            {
                return false;
            }

            return true;
        }

        private bool TryFindLocal(int dc, bool isMediaPreferred, [MaybeNullWhen(false)] out Connection connection)
        {
            foreach (var (conn, _) in _referenceCounts)
            {
                if (Matches(conn.ConnectionInfo, dc, isMediaPreferred) && !conn.ConnectionInfo.Main)
                {
                    connection = conn;
                    return true;
                }
            }

            connection = null;
            return false;
        }

        public async ValueTask DisposeAsync()
        {
            using (await _asyncLock.LockAsync())
            {
                foreach (var (conn, _) in _referenceCounts)
                {
                    if (_mainConnection == conn)
                    {
                        continue;
                    }

                    _logger.Information("Disposing connection {Conn}", conn);
                    await conn.DisposeAsync();
                }

                if (_mainConnection is not null)
                {
                    _logger.Information("Disposing main connection {Conn}", _mainConnection);
                    await _mainConnection.DisposeAsync();
                }
            }

            _asyncLock.Dispose();
            _logger.Information("Connection pool disposed");
        }
    }
}