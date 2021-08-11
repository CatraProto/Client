using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Flows.LoginFlow;
using CatraProto.Client.MTProto.Session;
using Serilog;

namespace CatraProto.Client
{
    public class TelegramClient
    {
        public Api? Api
        {
            get => _connectionPool.GetAccountConnection()?.MtProtoState.Api;
        }

        private readonly ConnectionPool _connectionPool;
        private readonly ClientSession _clientSession;
        private readonly ILogger _logger;

        public TelegramClient(ClientSession clientSession)
        {
            _clientSession = clientSession;
            _clientSession.SessionManager.ThrowIfNotRead();
            _logger = _clientSession.Logger.ForContext<TelegramClient>();
            _connectionPool = new ConnectionPool(clientSession.SessionManager.SessionData, clientSession.Settings, _logger);
        }

        public async Task<ClientState> StartAsync()
        {
            var sessionData = _clientSession.SessionManager.SessionData;
            var defaultConnection = await _connectionPool.GetConnectionAsync();

            if (!sessionData.Authorization.IsAuthorized(out var dcId))
            {
                return ClientState.NeedsLogin;
            }

            if (defaultConnection.ConnectionInfo.DcId == dcId)
            {
                _connectionPool.SetAccountConnection(defaultConnection);
                return ClientState.ReadyToUse;
            }

            var newConnection = await _connectionPool.GetConnectionByDcAsync(dcId!.Value);
            _connectionPool.SetAccountConnection(newConnection);
            return ClientState.ReadyToUse;
        }

        public LoginFlow GetLoginFlow()
        {
            return new LoginFlow(_connectionPool, _clientSession);
        }
    }
}