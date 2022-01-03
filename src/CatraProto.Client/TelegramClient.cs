using System;
using System.Threading.Tasks;
using CatraProto.Client.Flows.LoginFlow;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Settings;
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
                var accountConn = _clientSession.ConnectionPool.GetAccountConnection();
                if (accountConn is not null)
                {
                    return accountConn.MtProtoState.Api;
                }

                throw new InvalidOperationException("Please call InitClientAsync first");
            }
        }

        private readonly UpdatesHandler _updatesHandler;
        private readonly ClientSession _clientSession;
        private readonly ILogger _logger;
        
        public TelegramClient(IEventHandler eventHandler, ClientSettings clientSettings, ILogger logger)
        {
            _clientSession = new ClientSession(clientSettings, logger);
            _updatesHandler = new UpdatesHandler(eventHandler, _clientSession, this, logger);
            _clientSession.UpdatesHandler = _updatesHandler;
            _logger = _clientSession.Logger.ForContext<TelegramClient>();
        }

        public async Task<ClientState> InitClientAsync()
        {
            await _clientSession.ReadSessionAsync();
            var sessionData = _clientSession.SessionManager.SessionData;
            var defaultConnection = await _clientSession.ConnectionPool.GetConnectionAsync();

            if (!sessionData.Authorization.IsAuthorized(out var dcId, out _, out _))
            {
                return ClientState.Unauthenticated;
            }

            if (defaultConnection.ConnectionInfo.DcId == dcId)
            {
                _clientSession.ConnectionPool.SetAccountConnection(defaultConnection);
                return ClientState.Authenticated;
            }

            var newConnection = await _clientSession.ConnectionPool.GetConnectionByDcAsync(dcId!.Value);
            _clientSession.ConnectionPool.SetAccountConnection(newConnection);
            Task.Run(() => _updatesHandler.FetchLostUpdatesAsync());
            return ClientState.Authenticated;
        }

        public Task ForceSaveAsync()
        {
            return _clientSession.SaveSessionAsync();
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
        
        public async Task Listen()
        {
            //var instance = await Updates.UpdatesHandler.CreateInstance(_clientSession.SessionManager.SessionData, _connectionPool, _logger);
            //_connectionPool.GetAccountConnection()!.MessagesDispatcher.UpdatesHandler = instance;
        }
        
        public LoginFlow GetLoginFlow()
        {
            return new LoginFlow(this, _clientSession);
        }

        public async ValueTask DisposeAsync()
        {
            await _clientSession.DisposeAsync();
        }
    }
}