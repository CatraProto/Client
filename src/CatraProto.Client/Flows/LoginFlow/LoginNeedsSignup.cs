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
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using Authorization = CatraProto.Client.TL.Schemas.CloudChats.Auth.Authorization;

namespace CatraProto.Client.Flows.LoginFlow
{
    public class LoginNeedsSignup : ILoginResult
    {
        public TermsOfServiceBase? TermsOfService { get; }
        private readonly TelegramClient _client;
        private readonly SentCodeBase _sentCode;
        private readonly string _phoneNumber;
        private readonly SessionData _sessionData;

        internal LoginNeedsSignup(TelegramClient client, SentCodeBase sentCode, string phoneNumber, TermsOfServiceBase? termsOfService, SessionData sessionData)
        {
            TermsOfService = termsOfService;
            _client = client;
            _sentCode = sentCode;
            _phoneNumber = phoneNumber;
            _sessionData = sessionData;
        }

        public async Task<ILoginResult> WithProfileData(string firstName, string lastName, CancellationToken cancellationToken = default)
        {
            if (TermsOfService is not null)
            {
                await _client.Api.CloudChatsApi.Help.AcceptTermsOfServiceAsync(TermsOfService.Id);
            }

            var rpcQuery = await _client.Api.CloudChatsApi.Auth.SignUpAsync(_phoneNumber, _sentCode.PhoneCodeHash, firstName, lastName, cancellationToken: cancellationToken);
            if (rpcQuery.RpcCallFailed)
            {
                return new LoginFailed(rpcQuery.Error);
            }

            var authorization = (Authorization)rpcQuery.Response!;
            _sessionData.Authorization.SetAuthorized(true, rpcQuery.ExecutionInfo.ExecutedBy.DcId, authorization.User.Id, ((User)authorization.User).AccessHash!.Value);
            return new LoginSuccessful((User)authorization.User);
        }
    }
}