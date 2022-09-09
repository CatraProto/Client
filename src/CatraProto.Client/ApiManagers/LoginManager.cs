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

using System.Text;
using System.Threading.Tasks;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors.Login;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.Client.TL.Schemas.CloudChats.Langpack;
using CatraProto.Client.Tools;
using CatraProto.TL.Interfaces;
using Serilog;
using MTP = CatraProto.Client.TL.Schemas.MTProto;

namespace CatraProto.Client.ApiManagers
{
    public enum LoginState
    {
        AwaitingLogin,
        AwaitingCode,
        AwaitingPassword,
        AwaitingTermsAcceptance,
        AwaitingRegistration,
        LoggedIn,
        LoggedOut,
        SessionRevoked = 10000,
        AccountBanned,
        AccountDeactivated,
        KeyDuplicated = 20000,
    }

    public class LoginManager
    {
        private class PhoneData
        {
            public SentCodeTypeBase SentCodeType { get; set; }
            public CodeTypeBase? NextCodeType { get; set; }
            public string PhoneNumber { get; }
            public string PhoneHash { get; set; }

            public PhoneData(string phoneNumber, string phoneHash, SentCodeTypeBase type, CodeTypeBase? nextType)
            {
                PhoneNumber = phoneNumber;
                PhoneHash = phoneHash;
                SentCodeType = type;
                NextCodeType = nextType;
            }
        }

        private LoginState _currentState = LoginState.AwaitingLogin;
        private readonly SequentialInvoker _sequentialInvoker;
        private readonly object _stateMutex = new object();
        private readonly ClientSettings _clientSettings;
        private readonly SessionData _sessionData;
        private readonly TelegramClient _client;
        private readonly ILogger _logger;

        private PhoneData? _phoneData;
        private TermsOfService? _termsOfService;
        private string? _passwordHint;
        private PasswordAuthenticator? _passwordAuthenticator;

        internal LoginManager(TelegramClient client)
        {
            _client = client;
            _clientSettings = client.ClientSession.Settings;
            _sessionData = client.ClientSession.SessionManager.SessionData;
            _logger = client.GetLogger<LoginManager>();
            _sequentialInvoker = new SequentialInvoker(_logger);
        }

        internal void SendFirstState()
        {
            SetCurrentState(_sessionData.Authorization.GetAuthorization(out _, out _));
        }

        public async Task<RpcError?> UsePhoneNumberAsync(string phoneNumber, CodeSettings codeSettings)
        {
            if (GetCurrentState() is not LoginState.AwaitingLogin)
            {
                _logger.Information("Skipping AsUserAsync because state is not AwaitingLogin");
                return new InvalidTypeError();
            }

            _logger.Information("Sending authorization code to {Number}", phoneNumber);
            var auth = await _client.Api.CloudChatsApi.Auth.InternalSendCodeAsync(phoneNumber, _clientSettings.ApiSettings.ApiId, _clientSettings.ApiSettings.ApiHash, codeSettings);
            if (auth.RpcCallFailed)
            {
                if (auth.Error.ErrorMessage == "AUTH_RESTART")
                {
                    _logger.Information("Received AUTH_RESTART keeping state to AwaitingLogin and trying again...");
                    return await UsePhoneNumberAsync(phoneNumber, codeSettings);
                }

                _logger.Information("Send code failed because error {Error} occured", auth.Error);
                SetCurrentState(LoginState.AwaitingLogin);
                if (auth.Error.ErrorMessage == "PHONE_NUMBER_INVALID")
                {
                    return new PhoneNumberIncorrectError();
                }

                return auth.Error;
            }
            else
            {
                _logger.Information("Login code of type {Type} successfully sent", auth.Response.Type);
                _phoneData = new PhoneData(phoneNumber, auth.Response.PhoneCodeHash, auth.Response.Type, auth.Response.NextType);
                SetCurrentState(LoginState.AwaitingCode);
            }

            return null;
        }

        public async Task<RpcError?> UseBotTokenAsync(string token)
        {
            if (GetCurrentState() is not LoginState.AwaitingLogin)
            {
                _logger.Information("Skipping AsBotAsync because state is not AwaitingLogin");
                return null;
            }

            _logger.Information("Importing bot authorization {Token}", token);
            var auth = await _client.Api.CloudChatsApi.Auth.InternalImportBotAuthorizationAsync(0, _clientSettings.ApiSettings.ApiId, _clientSettings.ApiSettings.ApiHash, token);
            if (auth.RpcCallFailed)
            {
                _logger.Information("Received {Error} after calling auth.importBotAuthorization", auth.Error);
                SetCurrentState(LoginState.AwaitingLogin);
                if (auth.Error.ErrorMessage == "ACCESS_TOKEN_INVALID" || auth.Error.ErrorMessage == "ACCESS_TOKEN_EXPIRED")
                {
                    return new BotTokenIncorrectError();
                }

                return auth.Error;
            }

            if (auth.Response is not TL.Schemas.CloudChats.Auth.Authorization authorization)
            {
                _logger.Error("Unexpected type {Authorization} of authorization received for bot login", auth.Response);
                SetCurrentState(LoginState.AwaitingLogin);
                return null;
            }

            if (authorization.User is not User castedUser)
            {
                _logger.Error("Unexpected type {User} of user received for bot login", authorization.User);
                SetCurrentState(LoginState.AwaitingLogin);
                return null;
            }


            SetLoggedIn(castedUser, ((IRpcResponse)auth).ExecutionInfo.ExecutedBy.DcId, castedUser.Id);
            return null;
        }

        public async Task<RpcError?> UseLoginCodeAsync(string loginCode)
        {
            if (GetCurrentState() is not LoginState.AwaitingCode || _phoneData is null)
            {
                _logger.Information("Skipping UseLoginCodeAsync because state is not AwaitingLogin");
                return null;
            }

            _logger.Information("Trying to sign-in using code {Code}", loginCode);
            var query = await _client.Api.CloudChatsApi.Auth.InternalSignInAsync(_phoneData.PhoneNumber, _phoneData.PhoneHash, loginCode);
            if (query.RpcCallFailed)
            {
                _logger.Information("Received {Error} after calling auth.signIn", query.Error);
                if (query.Error.ErrorMessage == "SESSION_PASSWORD_NEEDED")
                {
                    SetCurrentState(LoginState.AwaitingPassword);
                    return null;
                }

                if (query.Error.ErrorMessage == "PHONE_CODE_INVALID" || query.Error.ErrorMessage == "PHONE_CODE_EMPTY")
                {
                    return new PhoneCodeIncorrectError();
                }

                SetCurrentState(LoginState.AwaitingLogin);
                return query.Error;
            }

            switch (query.Response)
            {
                case TL.Schemas.CloudChats.Auth.Authorization authorization when authorization.User is User user:
                    SetLoggedIn(user, ((IRpcResponse)query).ExecutionInfo.ExecutedBy.DcId, authorization.User.Id);
                    return null;
                case TL.Schemas.CloudChats.Auth.Authorization authorization when authorization.User is not User:
                    _logger.Error("Received invalid user {User} object in authorization constructor", authorization.User);
                    SetCurrentState(LoginState.AwaitingLogin);
                    return null;
                case AuthorizationSignUpRequired signUpRequired:
                    _logger.Information("Sign up for this phone number is required");
                    if (signUpRequired.TermsOfService is not null)
                    {
                        _logger.Information("Acceptance of terms of service is required");
                        _termsOfService = (TermsOfService)signUpRequired.TermsOfService;
                        SetCurrentState(LoginState.AwaitingTermsAcceptance);
                    }
                    else
                    {
                        SetCurrentState(LoginState.AwaitingRegistration);
                    }

                    return null;
                default:
                    _logger.Error("Received invalid response from server. Starting login from scratch. Received object: {Object}", query.Response.ToJson());
                    SetCurrentState(LoginState.AwaitingLogin);
                    return new InvalidTypeError();
            }
        }

        public async Task<RpcError?> ResendCodeAsync()
        {
            if (GetCurrentState() is not LoginState.AwaitingCode || _phoneData is null)
            {
                _logger.Information("Skipping ResendCodeAsync because state is not AwaitingLogin");
                return null;
            }

            _logger.Information("Resending login code to phone number {Number} and phone hash {Hash}", _phoneData.PhoneNumber, _phoneData.PhoneHash);
            var r = await _client.Api.CloudChatsApi.Auth.InternalResendCodeAsync(_phoneData.PhoneNumber, _phoneData.PhoneHash);
            if (r.RpcCallFailed)
            {
                if (r.Error.ErrorMessage != "SEND_CODE_UNAVAILABLE")
                {
                    SetCurrentState(LoginState.AwaitingLogin);
                }

                _logger.Information("Received {Error} after calling auth.resendCode", r.Error);
                return r.Error;
            }

            _phoneData.SentCodeType = r.Response.Type;
            _phoneData.NextCodeType = r.Response.NextType;
            _phoneData.PhoneHash = r.Response.PhoneCodeHash;
            return null;
        }

        public async Task<RpcError?> UseProfileDataAsync(string firstName, string lastName)
        {
            if (GetCurrentState() is not LoginState.AwaitingRegistration || _phoneData is null)
            {
                _logger.Information("Skipping RegisterUserAsync because state is not AwaitingRegistration");
                return null;
            }

            _logger.Information("Signing up as with first name: {FirstName} and last name: {LastName}", firstName, lastName);
            var rpcQuery = await _client.Api.CloudChatsApi.Auth.InternalSignUpAsync(_phoneData.PhoneNumber, _phoneData.PhoneHash, firstName, lastName);
            if (rpcQuery.RpcCallFailed)
            {
                SetCurrentState(LoginState.AwaitingLogin);
                return rpcQuery.Error;
            }

            if (rpcQuery.Response is not TL.Schemas.CloudChats.Auth.Authorization authorization)
            {
                _logger.Error("Unexpected type {Authorization} of authorization received for bot login", rpcQuery.Response);
                SetCurrentState(LoginState.AwaitingLogin);
                return null;
            }

            if (authorization.User is not User castedUser)
            {
                _logger.Error("Unexpected type {User} of user received for bot login", authorization.User);
                SetCurrentState(LoginState.AwaitingLogin);
                return null;
            }

            SetLoggedIn(castedUser, ((IRpcResponse)rpcQuery).ExecutionInfo.ExecutedBy.DcId, castedUser.Id);
            return null;
        }

        public async Task<RpcError?> UsePasswordAsync(string password)
        {
            if (GetCurrentState() is not LoginState.AwaitingPassword)
            {
                _logger.Information("Skipping UsePasswordAsync because state is not AwaitingPassword");
                return null;
            }

            if (_passwordAuthenticator is null)
            {
                var fetchResult = await FetchPasswordConfigAsync();
                if (fetchResult is not null)
                {
                    SetCurrentState(LoginState.AwaitingLogin);
                    return fetchResult;
                }
            }

            var computedSrp = _passwordAuthenticator!.CheckPassword(Encoding.UTF8.GetBytes(password));
            if (computedSrp.RpcCallFailed)
            {
                SetCurrentState(LoginState.AwaitingLogin);
                return computedSrp.Error;
            }

            _logger.Information("Checking password with srp_id {SrpId}", computedSrp.Response.SrpId);
            var checkPasswordResult = await _client.Api.CloudChatsApi.Auth.InternalCheckPasswordAsync(computedSrp.Response);
            if (checkPasswordResult.RpcCallFailed)
            {
                if (checkPasswordResult.Error.ErrorMessage == "PASSWORD_HASH_INVALID")
                {
                    _logger.Information("Provided password is not correct");
                    return new PasswordIncorrectError();
                }

                if (checkPasswordResult.Error.ErrorMessage == "SRP_ID_INVALID")
                {
                    _passwordAuthenticator = null;
                    _logger.Information("SRP token has expired, refetching data and retrying request...");
                    return await UsePasswordAsync(password);
                }

                _logger.Error("An error occurred while checking password. Logging out... Error: {Error}", checkPasswordResult.Error);
                var logOut = await _client.Api.CloudChatsApi.Auth.InternalLogOutAsync();
                if (logOut.RpcCallFailed)
                {
                    _logger.Error("Could not log out due to error: {Error}", logOut);
                }

                SetCurrentState(LoginState.AwaitingLogin);
                return checkPasswordResult.Error;
            }

            if (checkPasswordResult.Response is not TL.Schemas.CloudChats.Auth.Authorization authorization)
            {
                _logger.Error("Unexpected type {Authorization} of authorization received for password login", checkPasswordResult.Response);
                SetCurrentState(LoginState.AwaitingLogin);
                return null;
            }

            if (authorization.User is not User castedUser)
            {
                _logger.Error("Unexpected type {User} of user received for bot login", authorization.User);
                SetCurrentState(LoginState.AwaitingLogin);
                return null;
            }

            SetLoggedIn(castedUser, ((IRpcResponse)checkPasswordResult).ExecutionInfo.ExecutedBy.DcId, castedUser.Id);
            return null;
        }

        public void SetTerms(bool accept)
        {
            if (GetCurrentState() is not LoginState.AwaitingTermsAcceptance || _termsOfService is null)
            {
                _logger.Information("Skipping SetTermsAsync because state is not AwaitingTermsAcceptance");
                return;
            }

            if (accept)
            {
                _logger.Information("Terms of service accepted");
                SetCurrentState(LoginState.AwaitingRegistration);
            }
            else
            {
                _logger.Information("Terms of service declined");
                SetCurrentState(LoginState.AwaitingLogin);
            }

            return;
        }

        public async Task<RpcError?> LogoutAsync()
        {
            if (GetCurrentState() is not LoginState.LoggedIn)
            {
                _logger.Information("Skipping LogoutAsync because state is not LoggedIn");
                return null;
            }

            var req = await _client.Api.CloudChatsApi.Auth.InternalLogOutAsync();
            if (req.RpcCallFailed)
            {
                return req.Error;
            }

            SetCurrentState(LoginState.LoggedOut);
            return null;
        }

        public async Task CancelAsync()
        {
            var state = GetCurrentState();
            if (state >= LoginState.LoggedIn)
            {
                _logger.Information("Skipping CancelAsync because state is not higher or equal to LoggedIn");
                return;
            }

            if (state is LoginState.AwaitingCode && _phoneData is not null)
            {
                _logger.Information("Cancelling login code sento to phone number {Number} and phone hash {Hash}", _phoneData.PhoneNumber, _phoneData.PhoneHash);
                var cancelCode = await _client.Api.CloudChatsApi.Auth.CancelCodeAsync(_phoneData.PhoneNumber, _phoneData.PhoneHash);
                if (cancelCode.RpcCallFailed)
                {
                    _logger.Information("Failed to cancel login code due to {Error}", cancelCode.Error);
                }
            }

            _logger.Information("Logging out");
            var r = await _client.Api.CloudChatsApi.Auth.InternalLogOutAsync();
            if (r.RpcCallFailed)
            {
                _logger.Information("Failed to logout due to {Error}", r.Error);
            }

            SetCurrentState(LoginState.AwaitingLogin);
            return;
        }

        public (SentCodeTypeBase CodeType, CodeTypeBase? NextCodeType)? GetCodeTypes()
        {
            if (GetCurrentState() is not LoginState.AwaitingCode || _phoneData is null)
            {
                _logger.Information("Skipping GetCodeTypes because state is not AwaitingCode");
                return null;
            }

            return (_phoneData.SentCodeType, _phoneData.NextCodeType);
        }

        public TermsOfService? GetTermsOfService()
        {
            if (GetCurrentState() is not LoginState.AwaitingTermsAcceptance || _termsOfService is null)
            {
                _logger.Information("Skipping DeclineTermsAsync because state is not AwaitingTermsAcceptance");
                return null;
            }

            return (TermsOfService?)_termsOfService.Clone();
        }

        public string? GetPasswordHint()
        {
            if (GetCurrentState() is not LoginState.AwaitingPassword)
            {
                _logger.Information("Skipping GetPasswordHint because state is not AwaitingPassword");
                return null;
            }

            return _passwordHint;
        }

        private async Task<RpcError?> FetchPasswordConfigAsync()
        {
            _logger.Information("Account is protected by 2FA password, fetching password data...");
            var passwordData = await _client.Api.CloudChatsApi.Account.GetPasswordAsync();
            if (passwordData.RpcCallFailed)
            {
                SetCurrentState(LoginState.AwaitingLogin);
                return passwordData.Error;
            }

            _logger.Information("Fetched current 2FA configuration. SrpId: {SrpId}", passwordData.Response.SrpId);
            _passwordAuthenticator = new PasswordAuthenticator((Password)passwordData.Response, _logger);
            _passwordHint = ((Password)passwordData.Response).Hint;
            return null;
        }

        private void SetLoggedIn(User user, int dcId, long userId)
        {
            lock (_stateMutex)
            {
                _logger.Information("Successfully logged in! Current user: {User}", user.ToJson());
                _sessionData.Authorization.SetAuthorized(LoginState.LoggedIn, dcId, userId);
                SetCurrentState(LoginState.LoggedIn);
            }
        }

        private void SetCurrentState(LoginState newState)
        {
            lock (_stateMutex)
            {
                _logger.Information("Set new currentState {State}", newState);
                if (_currentState >= LoginState.LoggedOut)
                {
                    return;
                }

                _currentState = newState;
                // Won't save other states because they might not be valid and most of them require AwaitingLogin to be sent, if the client saves at the wrong time things could go wrong
                if (_currentState >= LoginState.LoggedOut)
                {
                    _sessionData.Authorization.SetAuthorized(_currentState, null, null);
                }

                if (_currentState >= LoginState.LoggedIn)
                {
                    _client.UpdatesReceiver.ForceGetDifferenceAllAsync(false);
                    _ = _client.ForceSaveAsync();
                }

                var ev = _client.EventHandler;
                if (ev is not null)
                {
                    _sequentialInvoker.Invoke(() => ev.OnSessionUpdateAsync(newState));
                }
            }
        }

        internal LoginState GetCurrentState()
        {
            lock (_stateMutex)
            {
                return _currentState;
            }
        }

        internal void OnErrorReceived(RpcError error, IMethod fromMethod)
        {
            lock (_stateMutex)
            {
                switch (fromMethod)
                {
                    case LogOut:
                    case SignIn:
                    case SignUp:
                    case SendCode:
                    case GetPassword:
                    case ResendCode:
                    case ImportBotAuthorization:
                        return;
                }

                if (error.ErrorMessage == "SESSION_REVOKED")
                {
                    SetCurrentState(LoginState.SessionRevoked);
                }
                else if (error.ErrorMessage == "AUTH_KEY_DROP_DUPLICATED")
                {
                    SetCurrentState(LoginState.KeyDuplicated);
                }
                else if (error.ErrorMessage == "ACCOUNT_BANNED")
                {
                    SetCurrentState(LoginState.AccountBanned);
                }
                else if (error.ErrorMessage == "USER_DEACTIVATED")
                {
                    SetCurrentState(LoginState.AccountDeactivated);
                }
                else if (error.ErrorMessage == "SESSION_EXPIRED")
                {
                    SetCurrentState(LoginState.SessionRevoked);
                }
                else if (error.ErrorMessage == "AUTH_KEY_UNREGISTERED" && _currentState is LoginState.LoggedIn)
                {
                    SetCurrentState(LoginState.SessionRevoked);
                }
                else
                {
                    return;
                }

                _logger.Information("Changing state because {Error} was received", error);
            }
        }

        public static bool CanBeUnauthenticated(IMethod method)
        {
            switch (method)
            {
                case LogOut:
                case GetCountriesList:
                case SendCode:
                case ResendCode:
                case GetPassword:
                case CheckPassword:
                case SignUp:
                case SignIn:
                case ImportAuthorization:
                case GetConfig:
                //This is missing from the documentation
                case ImportBotAuthorization:
                case GetNearestDc:
                case GetAppUpdate:
                case GetCdnConfig:
                case BindTempAuthKey:
                case GetLangPack:
                case GetStrings:
                //Langpack, not updates
                case GetDifference:
                case GetLanguage:
                case GetLanguages:

                //from TDLib
                case ExportLoginToken:
                case DropTempAuthKeys:
                case GetAppConfig:
                case SaveAppLog:

                //MtProto
                case MTP.GetFutureSalts:
                case MTP.ReqPq:
                case MTP.ReqPqMulti:
                case MTP.ReqDHParams:
                case MTP.SetClientDHParams:
                case MTP.PingDelayDisconnect:
                case MTP.Ping:
                case MTP.MsgsStateReq:
                case MTP.MsgResendReq:
                case MTP.MsgResendAnsReq:
                    return true;
            }

            return false;
        }
    }
}