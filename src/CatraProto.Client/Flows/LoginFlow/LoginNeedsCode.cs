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
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using Authorization = CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization;

namespace CatraProto.Client.Flows.LoginFlow
{
    public class LoginNeedsCode : ILoginResult
    {
        public SentCodeTypeBase CodeType { get; }
        private readonly TelegramClient _client;
        private readonly SentCodeBase _sentCode;
        private readonly string _phoneNumber;
        private readonly SessionData _sessionData;

        internal LoginNeedsCode(TelegramClient client, SentCodeBase sentCode, string phoneNumber, SessionData sessionData)
        {
            CodeType = sentCode.Type;
            _client = client;
            _sentCode = sentCode;
            _phoneNumber = phoneNumber;
            _sessionData = sessionData;
        }

        public async Task<ILoginResult> WithCodeAsync(string receivedCode, CancellationToken cancellationToken = default)
        {
            var query = await _client.Api!.CloudChatsApi.Auth.SignInAsync(_phoneNumber, _sentCode.PhoneCodeHash, receivedCode, cancellationToken: cancellationToken);
            if (query.RpcCallFailed)
            {
                return new LoginFailed(query.Error);
            }

            switch (query.Response)
            {
                case Authorization authorization:
                    _sessionData.Authorization.SetAuthorized(true, query.ExecutionInfo.ExecutedBy.DcId, authorization.User.Id, ((User)authorization.User).AccessHash!.Value);
                    return new LoginSuccessful((User)authorization.User);
                case AuthorizationSignUpRequired signUpRequired:
                    return new LoginNeedsSignup(_client, _sentCode, _phoneNumber, signUpRequired.TermsOfService, _sessionData);
                default:
                    return new LoginFailed(new UnknownError("Invalid type received", -1));
            }
        }
    }
}