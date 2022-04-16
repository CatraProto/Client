using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.Updates;
using Serilog;

namespace CatraProto.Client.Connections
{
    class ConnectionPool : IAsyncDisposable
    {
        private readonly Dictionary<Connection, int> _referenceCounts = new Dictionary<Connection, int>();
        private readonly TelegramClient _client;
        private readonly object _mutex = new object();
        private UpdatesReceiver? _updatesHandler;
        private Connection? _mainConnection;
        private readonly ILogger _logger;

        public ConnectionPool(TelegramClient client, ILogger logger)
        {
            _client = client;
            _logger = logger.ForContext<ConnectionPool>();
        }

        public async Task InitMainConnectionAsync(CancellationToken token)
        {
            var conn = new Connection(_client.ClientSession.Settings.ConnectionSettings.DefaultDatacenter, _client);
            await SetAccountConnectionAsync(conn, false);
            await conn.ConnectAsync(token);
        }

        public async ValueTask<ConnectionItem> GetConnectionByDcAsync(int dcId, bool forceNew, bool isMediaPreferred, CancellationToken token)
        {
            ConnectionItem connectionItem;
            var config = await _client.ConfigManager.GetConfigAsync(token);
            lock (_mutex)
            {
                if (!forceNew && TryFindLocal(dcId, isMediaPreferred, out var connection))
                {
                    return CreateConnectionItem(connection);
                }
                var isTestDc = _client.ClientSession.Settings.ConnectionSettings.DefaultDatacenter.Test;
                var matches = config.DcOptions.Where(x => Matches(ConnectionInfo.FromDcOption(x, isTestDc), dcId, isMediaPreferred)).OrderBy(x => x.MediaOnly).ToList();
                if (matches.Count == 0)
                {
                    throw new Exception("Couldn't find matching dcOption");
                }

                var datacenter = matches[0];
                var connectionInfo = new ConnectionInfo(IPAddress.Parse(datacenter.IpAddress), isTestDc, datacenter.Port, dcId);
                connectionItem = CreateConnectionItem(new Connection(connectionInfo, _client));
            }

            try
            {
                await connectionItem.Connection.ConnectAsync(token);
            }
            catch (OperationCanceledException)
            {
                await connectionItem.DisposeAsync();
                throw;
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

        public ValueTask DecreaseReferenceAsync(Connection connection)
        {
            lock (_mutex)
            {
                if (_referenceCounts.Remove(connection, out var rCount))
                {
                    if (rCount - 1 == 0)
                    {
                        if (_mainConnection != connection)
                        {
                            return connection.DisposeAsync();
                        }
                    }
                    else
                    {
                        _referenceCounts.Add(connection, --rCount);
                    }
                }

                return ValueTask.CompletedTask;
            }
        }

        public Connection? GetMainConnection()
        {
            lock (_mutex)
            {
                return _mainConnection;
            }
        }

        public void ConfirmMain()
        {
            lock (_mutex)
            {
                if(_mainConnection is not null)
                {
                    _mainConnection.ConnectionInfo.Main = true;
                }
            }
        }

        public async Task SetAccountConnectionAsync(Connection connection, bool isConfirmedMain)
        {
            ValueTask disposeTask = ValueTask.CompletedTask;
            lock (_mutex)
            {
                if(_mainConnection is not null)
                {
                    _mainConnection!.MessagesDispatcher.UpdatesHandler = null;
                    _mainConnection!.ConnectionInfo.Main = false;
                    if (_referenceCounts.TryGetValue(_mainConnection, out var count))
                    {
                        if (count == 0)
                        {
                            _referenceCounts.Remove(_mainConnection);
                            disposeTask = _mainConnection.DisposeAsync();
                        }
                    }
                    else
                    {
                        disposeTask = _mainConnection.DisposeAsync();
                    }
                }

                connection.MessagesDispatcher.UpdatesHandler = _updatesHandler;
                connection.ConnectionInfo.Main = isConfirmedMain;
                _mainConnection = connection;
            }

            await disposeTask;
        }

        public void SetUpdatesHandler(UpdatesReceiver updatesReceiver)
        {
            lock (_mutex)
            {
                _updatesHandler = updatesReceiver;
                if (_mainConnection != null)
                {
                    _mainConnection.MessagesDispatcher.UpdatesHandler = _updatesHandler;
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            ValueTask[] toWait;
            lock (_mutex)
            {
                toWait = new ValueTask[_referenceCounts.Count + 1];
                var i = 0;
                foreach(var (conn, _) in _referenceCounts)
                {
                    if(_mainConnection == conn)
                    {
                        continue;
                    }

                    toWait[i++] = conn.DisposeAsync();
                }

                toWait[_referenceCounts.Count] = _mainConnection is null ? ValueTask.CompletedTask : _mainConnection.DisposeAsync();
            }

            foreach (var vTask in toWait)
            {
                await vTask;
            }

            _logger.Information("Connection pool disposed");
        }

        private bool Matches(ConnectionInfo connectionInfo, int dcId, bool isMediaPreferred)
        {
            //TODO: Proper ipv6 support
            if(connectionInfo.DcId != dcId)
            {
                return false;
            }

            if(connectionInfo.Ipv6 && !_client.ClientSession.Settings.ConnectionSettings.Ipv6Allowed)
            {
                return false;
            }

            if(!connectionInfo.Ipv6 && _client.ClientSession.Settings.ConnectionSettings.Ipv6Only)
            {
                return false;
            }

            if(connectionInfo.MediaOnly && !isMediaPreferred)
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
                if (Matches(conn.ConnectionInfo, dc, isMediaPreferred))
                {
                    connection = conn;
                    return true;
                }
            }

            connection = null;
            return false;
        }
    }
}