using System;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Flows.LoginFlow;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.Updates;
using Serilog;
using Serilog.Core;

namespace CatraProto.Client
{
    public class TelegramClient : IAsyncDisposable
    {
        public Api? Api
        {
            get => _clientSession.ConnectionPool.GetAccountConnection()?.MtProtoState.Api;
        }

        private readonly ClientSession _clientSession;
        private readonly ILogger _logger;
        
        public TelegramClient(ClientSettings clientSettings, ILogger logger)
        {
            _clientSession = new ClientSession(clientSettings, logger);
            _logger = _clientSession.Logger.ForContext<TelegramClient>();
        }

        public async Task<ClientState> InitClientAsync()
        {
            await _clientSession.ReadSessionAsync();
            var sessionData = _clientSession.SessionManager.SessionData;
            var defaultConnection = await _clientSession.ConnectionPool.GetConnectionAsync();

            if (!sessionData.Authorization.IsAuthorized(out var dcId, out _, out _))
            {
                return ClientState.NeedsLogin;
            }

            if (defaultConnection.ConnectionInfo.DcId == dcId)
            {
                _clientSession.ConnectionPool.SetAccountConnection(defaultConnection);
                return ClientState.ReadyToUse;
            }

            var newConnection = await _clientSession.ConnectionPool.GetConnectionByDcAsync(dcId!.Value);
            _clientSession.ConnectionPool.SetAccountConnection(newConnection);
            return ClientState.ReadyToUse;
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
            return new LoginFlow(_clientSession.ConnectionPool, _clientSession);
        }

        public async ValueTask DisposeAsync()
        {
            await _clientSession.DisposeAsync();
        }
    }
}