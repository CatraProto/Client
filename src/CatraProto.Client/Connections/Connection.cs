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

        private readonly CancellationTokenSource _fullShutdownSource = new CancellationTokenSource();
        private readonly SingleCallAsync<CancellationToken> _singleCallAsync;
        private readonly TelegramClient _client;
        private readonly ClientSettings _clientSettings;
        private readonly ConnectionProtocol _protocolType;
        private readonly LoopsHandler _loopsHandler;
        private readonly ILogger _logger;
        private readonly bool _isInited;

        public Connection(ConnectionInfo connectionInfo, TelegramClient client)
        {
            _client = client;
            _logger = client.ClientSession.Logger.ForContext<Connection>();
            _clientSettings = client.ClientSession.Settings;
            _singleCallAsync = new SingleCallAsync<CancellationToken>(InternalConnectAsync);
            _protocolType = connectionInfo.ConnectionProtocol;
            _loopsHandler = new LoopsHandler(this, client.ClientSession.Settings, _logger);

            ConnectionInfo = connectionInfo;
            MessagesHandler = new MessagesHandler(this, client.ClientSession.Logger);
            MtProtoState = new MTProtoState(this, new Api(client, MessagesHandler.MessagesQueue), client);
            MessagesDispatcher = new MessagesDispatcher(this, MessagesHandler, MtProtoState, client.ClientSession);
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

            await DisconnectAsync();
            Protocol = CreateProtocol();
            token = CancellationTokenSource.CreateLinkedTokenSource(token, _fullShutdownSource.Token).Token;
            while (true)
            {
                try
                {
                    _logger.Information("Connecting to {Connection}", ConnectionInfo);
                    await Protocol.ConnectAsync(token);

                    _logger.Information("Successfully connected to {Connection}", ConnectionInfo);

                    await MtProtoState.StartSaltHandlerAsync();
                    await _loopsHandler.StartLoopsAsync();
                    break;
                }
                catch (SocketException e)
                {
                    var seconds = _clientSettings.ConnectionSettings.ConnectionRetry;
                    _logger.Error("Couldn't connect to {Connection} due to {Message}, trying again in {Seconds} seconds", ConnectionInfo, e.Message, seconds);
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(seconds), token);
                    }
                    catch (OperationCanceledException oe) when (oe.CancellationToken == token)
                    {
                        _logger.Information("Connection to {Connection} aborted", ConnectionInfo);
                        return;
                    }
                }
                catch (OperationCanceledException e) when (e.CancellationToken == token)
                {
                    _logger.Information("Connection to {Connection} aborted", ConnectionInfo);
                    return;
                }
            }
        }

        private async Task DisconnectAsync()
        {
            _logger.Information("Disconnecting from {Connection} and stopping existing loops", ConnectionInfo);
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

        public void SignalNewMessage()
        {
            _loopsHandler.WakeUpWriteLoop();
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

        public async ValueTask DisposeAsync()
        {
            _fullShutdownSource.Cancel();
            //Make sure we are returning only after Task.Delay returned by calling ConnectAsync
            //This call will wait for the previous one (if exists) to return, this call may have not created a connection yet or it may have already destroyed the previous one 
            await ConnectAsync();
            //Since we can't be sure, we call DisconnectAsync manually.
            await DisconnectAsync();
            await MtProtoState.StopSaltHandlerAsync();
            _fullShutdownSource.Dispose();
            _logger.Information("Connection for {Connection} successfully disposed", ConnectionInfo);
        }
    }
}