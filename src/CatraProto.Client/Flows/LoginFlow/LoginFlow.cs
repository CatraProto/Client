using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.Flows.LoginFlow.Interfaces;
using CatraProto.Client.Flows.LoginFlow.Results;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations;
using CatraProto.Client.MTProto.Rpc.RpcErrors.Migrations.Interfaces;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Session.Models;
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
        private readonly SessionData _sessionData;
        private readonly ILogger _logger;

        internal LoginFlow(ConnectionPool connectionPool, ClientSession clientSession)
        {
            _connectionPool = connectionPool;
            _clientSettings = clientSession.Settings;
            _sessionData = clientSession.SessionManager.SessionData;
            _logger = clientSession.Logger.ForContext<LoginFlow>();
        }

        public Task<ILoginResult> AsUserAsync(string phoneNumber, CodeSettings codeSettings)
        {
            return InternalAsUserAsync(phoneNumber, codeSettings, null);
        }

        private async Task<ILoginResult> InternalAsUserAsync(string phoneNumber, CodeSettings codeSettings, int? dc)
        {
            var connection = await GetConnectionAsync(dc);
            var api = connection.MtProtoState.Api;
            _logger.Information("Sending authorization code to {Number}", phoneNumber);
            var auth = await api.CloudChatsApi.Auth.SendCodeAsync(phoneNumber, _clientSettings.ApiSettings.ApiId, _clientSettings.ApiSettings.ApiHash, codeSettings);
            if (auth.Error != null)
            {
                switch (auth.Error)
                {
                    case IMigrateError migrateError:
                        _logger.Information("DC{DcId} redirected login to DC{NewDc} due to {Error}", connection.ConnectionInfo.DcId, migrateError.DcId, auth.Error.ErrorCode);
                        return await InternalAsUserAsync(phoneNumber, codeSettings, migrateError.DcId);
                    default:
                        _logger.Error("Login failed due to {Error}", auth.Error);
                        return new LoginFailed(auth.Error);
                }
            }

            _connectionPool.SetAccountConnection(connection);

            _logger.Information("Login code of type {Type} successfully sent", auth.Response!);
            return new LoginNeedsCode(connection, auth.Response!, phoneNumber, _sessionData);
        }

        public Task<ILoginResult> AsBotAsync(string token)
        {
            _logger.Information("Logging in as a bot using token {Token}", token);
            return InternalAsBotAsync(token, null);
        }

        private async Task<ILoginResult> InternalAsBotAsync(string token, int? dc)
        {
            var connection = await GetConnectionAsync(dc);
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

            var user = (User)((Authorization)auth.Response!).User;
            _connectionPool.SetAccountConnection(connection);
            _sessionData.Authorization.SetAuthorized(true, connection.ConnectionInfo.DcId, user.Id, user.AccessHash!.Value);
            _logger.Information("Successfully logged in as @{BotUsername}", user.Username);
            return new LoginSuccessful();
        }

        private async ValueTask<Connection> GetConnectionAsync(int? dc)
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

            return connection;
        }
    }
}