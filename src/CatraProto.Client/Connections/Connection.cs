﻿/*
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
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using CatraProto.Client.MTProto.Settings;
using Serilog;

namespace CatraProto.Client.Connections
{
    internal class Connection : IAsyncDisposable
    {
        public MTProtoState MtProtoState { get; }
        public MessagesHandler MessagesHandler { get; }
        public MessagesDispatcher MessagesDispatcher { get; }
        public ConnectionInfo ConnectionInfo { get; }
        public IProtocol Protocol { get; private set; }

        private CancellationTokenSource _fullShutdownSource = new CancellationTokenSource();
        private readonly SingleCallAsync<CancellationToken> _singleCallAsync;
        private readonly AsyncLock _lock = new AsyncLock();
        private readonly ConnectionProtocol _protocolType;
        private readonly ClientSettings _clientSettings;
        private readonly LoopsHandler _loopsHandler;
        private readonly TelegramClient _client;
        private readonly ILogger _logger;
        private bool _isDisposed = false;
        public Connection(ConnectionInfo connectionInfo, TelegramClient client)
        {
            _client = client;
            _logger = client.ClientSession.Logger.ForContext<Connection>().ForContext("Connection", connectionInfo);
            _clientSettings = client.ClientSession.Settings;
            _singleCallAsync = new SingleCallAsync<CancellationToken>(InternalConnectAsync);
            _protocolType = connectionInfo.ConnectionProtocol;
            _loopsHandler = new LoopsHandler(this, client.ClientSession.Settings, _logger);

            ConnectionInfo = connectionInfo;
            MessagesHandler = new MessagesHandler(this, _logger);
            MtProtoState = new MTProtoState(this, new Api(client, MessagesHandler.MessagesQueue), client, _logger);
            MessagesDispatcher = new MessagesDispatcher(this, MessagesHandler, MtProtoState, client.ClientSession, _logger);
            Protocol = CreateProtocol();
        }

        public Task ConnectAsync(CancellationToken token = default)
        {
            return _singleCallAsync.GetCall(token);
        }

        private async Task InternalConnectAsync(CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }

            using var lk = await _lock.LockAsync(token);
            await DisconnectAsync();
            Protocol = CreateProtocol();
            token = CancellationTokenSource.CreateLinkedTokenSource(token, _fullShutdownSource.Token).Token;
            while (true)
            {
                try
                {
                    _logger.Information("Connecting...");
                    await Protocol.ConnectAsync(token);
                    _logger.Information("Successfully connected");
                    await _loopsHandler.StartLoopsAsync();
                    break;
                }
                catch (SocketException e)
                {
                    var seconds = _clientSettings.ConnectionSettings.ConnectionRetry;
                    _logger.Error("Couldn't connect due to {Message}, trying again in {Seconds} seconds", e.Message, seconds);
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(seconds), token);
                    }
                    catch (OperationCanceledException oe) when (oe.CancellationToken == token)
                    {
                        _logger.Information("Connection aborted");
                        return;
                    }
                }
                catch (OperationCanceledException e) when (e.CancellationToken == token)
                {
                    _logger.Information("Connection aborted");
                    return;
                }
            }
        }

        private async Task DisconnectAsync()
        {
            _logger.Information("Disconnecting and stopping existing loops");
            await _loopsHandler.StopLoopsAsync();
            await Protocol.CloseAsync();
        }

        public void OnKeyGenerated()
        {
            _logger.Information("Resetting key loop timer after key generation and forcing updates");
            _loopsHandler.ResetKeyLoop();
            SignalNewMessage();
        }

        private IProtocol CreateProtocol()
        {
            switch (_protocolType)
            {
                case ConnectionProtocol.TcpAbridged:
                    return new Abridged(ConnectionInfo, _logger);
                default:
                    throw new NotSupportedException("Protocol not supported");
            }
        }

        public void SignalNewMessage(bool onlyIfSuspended = true)
        {
            _loopsHandler.WakeUpWriteLoop(onlyIfSuspended);
        }

        public void RegenKey()
        {
            if (!MtProtoState.KeysHandler.TemporaryAuthKey.HasExpired())
            {
                _logger.Information("Waking up loop to regen key and resetting timer");
                MtProtoState.KeysHandler.TemporaryAuthKey.SetExpired();
                _loopsHandler.WakeUpKeyLoop();
            }
        }

        public async Task<IDisposable> DisconnectAndLockAsync()
        {
            _logger.Information("Forcefully disconnecting");
            _fullShutdownSource.Cancel();

            //Connect async has already exited after acquiring lock
            var lk = await _lock.LockAsync();

            //At this point, any call to ConnectAsync will have to wait for the lock to be released
            //So we can safely replace the cancellation token as it will not be used
            _fullShutdownSource.Dispose();
            _fullShutdownSource = new CancellationTokenSource();

            //Make sure the connection is actually closed
            await DisconnectAsync();
            _logger.Information("Disconnected");
            return lk;
        }

        public async ValueTask DisposeAsync()
        {
            if (_isDisposed)
            {
                return;
            }

            (await DisconnectAndLockAsync()).Dispose();
            _lock.Dispose();
            _fullShutdownSource.Dispose();

            _isDisposed = true;
            _logger.Information("Connection successfully disposed");
        }
    }
}