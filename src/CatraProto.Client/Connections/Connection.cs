using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.Client.TL.Schemas.MTProto;
using Serilog;

namespace CatraProto.Client.Connections
{
    class Connection : IAsyncDisposable
    {
        public MTProtoState MtProtoState { get; }
        public MessagesHandler MessagesHandler { get; }
        public MessagesDispatcher MessagesDispatcher { get; }
        public ConnectionInfo ConnectionInfo { get; }
        public IProtocol Protocol { get; private set; }

        private readonly SingleCallAsync<CancellationToken> _singleCallAsync;
        private readonly ClientSettings _clientSettings;
        private readonly ConnectionProtocol _protocolType;
        private readonly LoopsHandler _loopsHandler;
        private readonly object _mutex = new object();
        private readonly ILogger _logger;
        private bool _isInited;

        public Connection(ConnectionInfo connectionInfo, ClientSession clientSession)
        {
            _logger = clientSession.Logger.ForContext<Connection>();
            ConnectionInfo = connectionInfo;
            _loopsHandler = new LoopsHandler(this, clientSession.Settings, _logger);
            MessagesHandler = new MessagesHandler(this, clientSession.Logger);
            MtProtoState = new MTProtoState(this, new Api(MessagesHandler.MessagesQueue), clientSession);
            _clientSettings = clientSession.Settings;
            MessagesDispatcher = new MessagesDispatcher(this, MessagesHandler, MtProtoState, clientSession);
            _singleCallAsync = new SingleCallAsync<CancellationToken>(InternalConnectAsync);
            _protocolType = connectionInfo.ConnectionProtocol;
            Protocol = CreateProtocol();
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

        public Task ConnectAsync(CancellationToken token = default)
        {
            return _singleCallAsync.GetCall(token);
        }

        private async Task InternalConnectAsync(CancellationToken token)
        {
            _logger.Information("Stopping loops and creating protocol for {Connection}", ConnectionInfo);
            await _loopsHandler.StopLoopsAsync();
            await Protocol.CloseAsync();

            SetIsInited(false);
            Protocol = CreateProtocol();
            while (true)
            {
                try
                {
                    _logger.Information("Connecting to {Connection}", ConnectionInfo);
                    await Protocol.ConnectAsync(token);
                    break;
                }
                catch (SocketException e)
                {
                    var seconds = _clientSettings.ConnectionSettings.ConnectionTimeout;
                    _logger.Error("Couldn't connect to {Connection} due to {Message}, trying again in {Seconds} seconds", ConnectionInfo, e.Message, seconds);
                    await Task.Delay(TimeSpan.FromSeconds(seconds), token);
                }
            }

            _logger.Information("Successfully connected to {Connection}", ConnectionInfo);
            await _loopsHandler.StartLoopsAsync();
        }


        public async Task InitConnectionAsync(CancellationToken token = default)
        {
            _logger.Information("Initializing connection {Connection}", ConnectionInfo);
            var initConnection = new InitConnection
            {
                ApiId = _clientSettings.ApiSettings.ApiId,
                AppVersion = _clientSettings.ApiSettings.AppVersion,
                DeviceModel = _clientSettings.ApiSettings.DeviceModel,
                LangCode = _clientSettings.ApiSettings.LangCode,
                LangPack = _clientSettings.ApiSettings.LangPack,
                SystemLangCode = _clientSettings.ApiSettings.SystemLangCode,
                SystemVersion = _clientSettings.ApiSettings.SystemVersion,
                Query = new GetConfig()
            };

            await MtProtoState.Api.CloudChatsApi.InvokeWithLayerAsync(MergedProvider.LayerId, initConnection, cancellationToken: token);
            SetIsInited(true);

            _logger.Information("Connection {Connection} initialized", ConnectionInfo);
            // var unanswered = MessagesHandler.MessagesTrackers.MessageCompletionTracker.GetUnanswered(false).Select(x => x.GetProtocolInfo().MessageId!.Value).ToList();
            // if (unanswered.Count > 0)
            // {
            //     var stateReq = new MsgsStateReq
            //     {
            //         MsgIds = unanswered
            //     };
            //     
            //     MessagesHandler.MessagesQueue.SendObject(stateReq, new MessageSendingOptions(true), CancellationToken.None);
            // }
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

        public bool GetIsInited()
        {
            lock (_mutex)
            {
                return _isInited;
            }
        }

        public void SetIsInited(bool value)
        {
            lock (_mutex)
            {
                _isInited = value;
            }
        }

        public async ValueTask DisposeAsync()
        {
            //TODO: FIX
            //MessagesHandler.MessagesTrackers.MessagesAckTracker.Stop();
            await _loopsHandler.StopLoopsAsync();
        }
    }
}