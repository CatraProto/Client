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

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Crypto;
using CatraProto.Client.Flows.LoginFlow.Interfaces;
using CatraProto.Client.Flows.LoginFlow.Results;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using Serilog;
using Authorization = CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization;

namespace CatraProto.Client.Flows.LoginFlow
{
    public class LoginNeedsPassword : ILoginResult
    {
        private PasswordAuthenticator _passwordAuthenticator;
        private readonly SessionData _sessionData;
        private readonly TelegramClient _client;
        private readonly ILogger _logger;

        private LoginNeedsPassword(TelegramClient client, Password password, SessionData sessionData, ILogger logger)
        {
            _sessionData = sessionData;
            _logger = logger.ForContext<LoginNeedsPassword>();
            _client = client;
            _passwordAuthenticator = new PasswordAuthenticator(password, _logger);
        }

        internal static async Task<RpcResponse<LoginNeedsPassword>> CreateAsync(TelegramClient client, SessionData sessionData, ILogger logger, CancellationToken token)
        {
            logger = logger.ForContext<LoginNeedsPassword>();
            logger.Information("Requesting password information...");
            var response = await client.Api.CloudChatsApi.Account.GetPasswordAsync(cancellationToken: token);
            if (response.RpcCallFailed)
            {
                logger.Error("Password information request failed with error: {Error}", response.Error);
                return RpcResponse<LoginNeedsPassword>.FromError(response.Error);
            }

            var password = (Password)response.Response;
            if (password.CurrentAlgo is PasswordKdfAlgoUnknown)
            {
                logger.Error("Unknown password algorithm received");
                return RpcResponse<LoginNeedsPassword>.FromError(new InvalidDataError("Invalid password algorithm"));
            }

            logger.Information("Password data is valid");
            return RpcResponse<LoginNeedsPassword>.FromResult(new LoginNeedsPassword(client, password, sessionData, logger));
        }

        public async Task<ILoginResult> WithPasswordAsync(string password, CancellationToken token = default)
        {
            var asBytes = Encoding.UTF8.GetBytes(password);
            var inputPassword = _passwordAuthenticator.CheckPassword(asBytes);
            if (inputPassword.RpcCallFailed)
            {
                return new LoginFailed(inputPassword.Error);
            }

            var query = await _client.Api.CloudChatsApi.Auth.CheckPasswordAsync(inputPassword.Response, cancellationToken: token);
            if (query.RpcCallFailed)
            {
                if (query.Error.ErrorMessage == "SRP_ID_INVALID")
                {
                    _logger.Information("Received SRP_ID_INVALID, re-fetching password information and trying again");
                    var response = await _client.Api.CloudChatsApi.Account.GetPasswordAsync(cancellationToken: token);
                    if (response.RpcCallFailed)
                    {
                        _logger.Error("Password information request failed with error: {Error}", response.Error);
                        return new LoginFailed(response.Error);
                    }

                    var passworda = (Password)response.Response;
                    _passwordAuthenticator = new PasswordAuthenticator(passworda, _logger);
                    return await WithPasswordAsync(password, token);
                }

                return new LoginFailed(query.Error);
            }

            switch (query.Response)
            {
                case Authorization authorization:
                    _sessionData.Authorization.SetAuthorized(true, query.ExecutionInfo.ExecutedBy.DcId, authorization.User.Id, ((User)authorization.User).AccessHash!.Value);
                    return new LoginSuccessful((User)authorization.User);
                default:
                    return new LoginFailed(new InvalidTypeError());
            }
        }
    }
}