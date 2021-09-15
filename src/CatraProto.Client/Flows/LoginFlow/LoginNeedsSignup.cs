using System.Threading.Tasks;
using CatraProto.Client.Connections;
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
        public TermsOfServiceBase TermsOfService { get; }
        private readonly Connection _connection;
        private readonly SentCodeBase _sentCode;
        private readonly string _phoneNumber;
        private readonly SessionData _sessionData;

        internal LoginNeedsSignup(Connection connection, SentCodeBase sentCode, string phoneNumber, TermsOfServiceBase termsOfService,
            SessionData sessionData)
        {
            TermsOfService = termsOfService;
            _connection = connection;
            _sentCode = sentCode;
            _phoneNumber = phoneNumber;
            _sessionData = sessionData;
        }

        public async Task<ILoginResult> WithProfileData(string firstName, string lastName)
        {
            var api = _connection.MtProtoState.Api;
            await api.CloudChatsApi.Help.AcceptTermsOfServiceAsync(TermsOfService.Id);
            var rpcQuery = await api.CloudChatsApi.Auth.SignUpAsync(_phoneNumber, _sentCode.PhoneCodeHash, firstName, lastName);
            if (rpcQuery.Error != null)
            {
                return new LoginFailed(rpcQuery.Error);
            }

            var authorization = (Authorization)rpcQuery.Response!;
            _sessionData.Authorization.SetAuthorized(true, _connection.ConnectionInfo.DcId, authorization.User.Id,
                ((User)authorization.User).AccessHash!.Value);
            return new LoginSuccessful((User)authorization.User);
        }
    }
}