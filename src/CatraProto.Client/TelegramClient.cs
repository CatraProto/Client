using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Database;
using CatraProto.Client.Flows.LoginFlow;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.Updates;
using CatraProto.Client.Updates.Interfaces;
using Serilog;
using Serilog.Core;

namespace CatraProto.Client
{
    public class TelegramClient : IAsyncDisposable
    {
        public Api Api
        {
            get
            {
                var accountConn = ClientSession.ConnectionPool.GetMainConnection();
                if (accountConn is not null)
                {
                    return accountConn.MtProtoState.Api;
                }

                throw new InvalidOperationException("Please call InitClientAsync first");
            }
        }

        internal RandomId RandomIdHandler
        {
            get => _randomIdHandler ?? throw new InvalidOperationException("Please call InitClientAsync first");
        }

        internal Config StoredConfig
        {
            get => _config ?? throw new InvalidOperationException("Please call InitClientAsync first");
        }

        internal DatabaseManager DatabaseManager { get; }
        internal UpdatesReceiver UpdatesReceiver { get; }
        internal ClientSession ClientSession { get; }
        internal UpdatesDispatcher UpdatesDispatcher { get; }
        internal IEventHandler? EventHandler { get; private set; }
        private Config? _config;
        private RandomId? _randomIdHandler;
        private readonly SessionEvents _sessionEvents;
        private readonly ILogger _logger;

        public TelegramClient(ClientSettings clientSettings, ILogger logger)
        {
            ClientSession = new ClientSession(this, clientSettings, logger);
            DatabaseManager = new DatabaseManager(this, ClientSession.Logger);
            UpdatesReceiver = new UpdatesReceiver(this, ClientSession.Logger);
            _sessionEvents = new SessionEvents(this, ClientSession.Logger);
            UpdatesDispatcher = new UpdatesDispatcher(this, ClientSession.Logger);
            _logger = ClientSession.Logger.ForContext<TelegramClient>();
        }

        public async Task<ClientState> InitClientAsync(CancellationToken token = default)
        {
            await ClientSession.ReadSessionAsync(token);
            _randomIdHandler = ClientSession.SessionManager.SessionData.RandomId;
            DatabaseManager.InitDb();
            var sessionData = ClientSession.SessionManager.SessionData;
            sessionData.RegisterOnUpdated(_sessionEvents.OnDataUpdate);
            
            await ClientSession.ConnectionPool.InitMainConnectionAsync(token);
            _logger.Information("Requesting and storing current configuration");
            _config = (Config)(await Api.CloudChatsApi.Help.GetConfigAsync(cancellationToken: token)).Response;

            if (!sessionData.Authorization.IsAuthorized(out var dcId, out _, out _))
            {
                return ClientState.Unauthenticated;
            }

            if (ClientSession.ConnectionPool.GetMainConnection()!.ConnectionInfo.DcId == dcId)
            {
                ClientSession.ConnectionPool.ConfirmMain();
            }
            else
            {
                await using var newConnection = await ClientSession.ConnectionPool.GetConnectionByDcAsync(dcId!.Value, false, false, token);
                await ClientSession.ConnectionPool.SetAccountConnectionAsync(newConnection.Connection, true);
            }
            
            UpdatesReceiver.FillProcessors();
            return ClientState.Authenticated;
        }

        public void SetEventHandler(IEventHandler eventHandler)
        {
            if (EventHandler is null)
            {
                EventHandler = eventHandler;
                ClientSession.ConnectionPool.SetUpdatesHandler(UpdatesReceiver);
            }
            else
            {
                throw new InvalidOperationException("Event handler is already set");
            }
        }

        public Task ForceSaveAsync(CancellationToken token = default)
        {
            return ClientSession.SaveSessionAsync(token);
        }

        public ILogger GetLogger<T>()
        {
            // ReSharper disable once ContextualLoggerProblem
            return _logger.ForContext<T>();
        }

        public ILogger GetLogger(string contextName)
        {
            return _logger.ForContext(Constants.SourceContextPropertyName, contextName);
        }

        public LoginFlow GetLoginFlow()
        {
            return new LoginFlow(this, ClientSession);
        }

        public async ValueTask DisposeAsync()
        {
            await ClientSession.DisposeAsync();
        }
    }
}