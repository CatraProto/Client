using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Flows.LoginFlow.Interfaces;
using CatraProto.Client.Flows.LoginFlow.Results;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL.Schemas.CloudChats;
using Serilog;
using Authorization = CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization;

namespace CatraProto.Client.Flows.LoginFlow
{
    public class LoginFlow
    {
        private readonly ConnectionPool _connectionPool;
        private readonly ClientSettings _clientSettings;
        private readonly ILogger _logger;

        internal LoginFlow(ConnectionPool connectionPool, ClientSession clientSession)
        {
            _connectionPool = connectionPool;
            _clientSettings = clientSession.Settings;
            _logger = clientSession.Logger.ForContext<LoginFlow>();
        }

        public Task<ILoginResult> AsBotAsync(string token)
        {
            _logger.Information("Logging in as a bot using token {Token}", token);
            return InternalAsBotAsync(token, null);
        }

        private async Task<ILoginResult> InternalAsBotAsync(string token, int? dc)
        {
            Connection connection;
            if (dc == null)
            {
                connection = await _connectionPool.GetConnectionAsync();
            }
            else
            {
                connection = await _connectionPool.GetConnectionByDcAsync(dc.Value);
            }

            var api = connection.MtProtoState.Api;
            var auth = await api.CloudChatsApi.Auth.ImportBotAuthorizationAsync(0, _clientSettings.ApiSettings.ApiId, _clientSettings.ApiSettings.ApiHash, token);
            if (auth.Error != null)
            {
                switch (auth.Error)
                {
                    case UserMigrateError migrateError:
                        _logger.Information("DC{DcId} redirected login to DC{NewDc}", connection.ConnectionInfo.DcId, migrateError.DcId);
                        return await InternalAsBotAsync(token, migrateError.DcId);
                    default:
                        return new LoginFailed(auth.Error);
                }
            }

            _connectionPool.SetAccountConnection(connection);
            _logger.Information("Successfully logged in as @{BotUsername}", ((User)((Authorization)auth.Response!).User).Username);
            return new LoginSuccessful();
        }
    }
}