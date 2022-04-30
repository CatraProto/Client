/*
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