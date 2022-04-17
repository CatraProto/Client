using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Flows.LoginFlow.Interfaces;
using CatraProto.Client.Flows.LoginFlow.Results;
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
        private readonly TelegramClient _client;
        private readonly ClientSettings _clientSettings;
        private readonly SessionData _sessionData;
        private readonly ILogger _logger;

        internal LoginFlow(TelegramClient client, ClientSession clientSession)
        {
            _client = client;
            _clientSettings = clientSession.Settings;
            _sessionData = clientSession.SessionManager.SessionData;
            _logger = clientSession.Logger.ForContext<LoginFlow>();
        }

        public async Task<ILoginResult> AsUserAsync(string phoneNumber, CodeSettings codeSettings, CancellationToken cancellationToken = default)
        {
            _logger.Information("Sending authorization code to {Number}", phoneNumber);
            var auth = await _client.Api.CloudChatsApi.Auth.SendCodeAsync(phoneNumber, _clientSettings.ApiSettings.ApiId, _clientSettings.ApiSettings.ApiHash, codeSettings, cancellationToken: cancellationToken);
            if (auth.RpcCallFailed)
            {
                _logger.Error("Login failed due to {Error}", auth.Error);
                return new LoginFailed(auth.Error);
            }

            _logger.Information("Login code of type {Type} successfully sent", auth.Response.Type.ToString());
            return new LoginNeedsCode(_client, auth.Response, phoneNumber, _sessionData);
        }

        public async Task<ILoginResult> AsBotAsync(string token, CancellationToken cancellationToken = default)
        {
            var auth = await _client.Api!.CloudChatsApi.Auth.ImportBotAuthorizationAsync(0, _clientSettings.ApiSettings.ApiId, _clientSettings.ApiSettings.ApiHash, token, cancellationToken: cancellationToken);
            if (auth.RpcCallFailed)
            {
                return new LoginFailed(auth.Error);
            }

            var user = (User)((Authorization)auth.Response).User;
            _sessionData.Authorization.SetAuthorized(true, auth.ExecutionInfo.ExecutedBy.DcId, user.Id, user.AccessHash!.Value);
            _logger.Information("Successfully logged in as @{BotUsername}", user.Username);
            return new LoginSuccessful(user);
        }
    }
}