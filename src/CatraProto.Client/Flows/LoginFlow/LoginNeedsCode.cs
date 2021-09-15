using System.Threading.Tasks;
using CatraProto.Client.Connections;
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
        private readonly Connection _connection;
        private readonly SentCodeBase _sentCode;
        private readonly string _phoneNumber;
        private readonly SessionData _sessionData;

        internal LoginNeedsCode(Connection connection, SentCodeBase sentCode, string phoneNumber, SessionData sessionData)
        {
            CodeType = sentCode.Type;
            _connection = connection;
            _sentCode = sentCode;
            _phoneNumber = phoneNumber;
            _sessionData = sessionData;
        }

        public async Task<ILoginResult> WithCodeAsync(string receivedCode)
        {
            var api = _connection.MtProtoState.Api;
            var query = await api.CloudChatsApi.Auth.SignInAsync(_phoneNumber, _sentCode.PhoneCodeHash, receivedCode);
            if (query.Error != null)
            {
                return new LoginFailed(query.Error);
            }

            switch (query.Response!)
            {
                case Authorization authorization:
                    _sessionData.Authorization.SetAuthorized(true, _connection.ConnectionInfo.DcId, authorization.User.Id,
                        ((User)authorization.User).AccessHash!.Value);
                    return new LoginSuccessful((User)authorization.User);
                case AuthorizationSignUpRequired signUpRequired:
                    return new LoginNeedsSignup(_connection, _sentCode, _phoneNumber, signUpRequired.TermsOfService, _sessionData);
                default:
                    return new LoginFailed(new UnknownError("Invalid type received", -1));
            }
        }
    }
}