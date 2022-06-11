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
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using CatraProto.Client.TL.Schemas.CloudChats.Help;
using CatraProto.Client.TL.Schemas.CloudChats.Langpack;
using MTP = CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.Client.Tools;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.ApiManagers
{
    public enum LoginState
    {
        AwaitingLogin,
        AwaitingCode,
        AwaitingPassword,
        AwaitingRegistration,
        AwaitingTermsAcceptance,
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

        public async Task<RpcError?> UsePhoneNumberAsync(string phoneNumber, CodeSettings codeSettings, CancellationToken cancellationToken = default)
        {
            if (GetCurrentState() is not LoginState.AwaitingLogin)
            {
                _logger.Warning("Skipping AsUserAsync because state is not AwaitingLogin");
                return new InvalidTypeError();
            }

            _logger.Information("Sending authorization code to {Number}", phoneNumber);
            var auth = await _client.Api.CloudChatsApi.Auth.SendCodeAsync(phoneNumber, _clientSettings.ApiSettings.ApiId, _clientSettings.ApiSettings.ApiHash, codeSettings, cancellationToken: cancellationToken);
            if (auth.RpcCallFailed)
            {
                if (auth.Error.ErrorMessage == "AUTH_RESTART")
                {
                    _logger.Information("Received AUTH_RESTART keeping state to AwaitingLogin and trying again...");
                    return await UsePhoneNumberAsync(phoneNumber, codeSettings, cancellationToken);
                }

                _logger.Information("Send code failed because error {Error} occured", auth.Error);
                SetCurrentState(LoginState.AwaitingLogin);
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

        public async Task<RpcError?> UseBotTokenAsync(string token, CancellationToken cancellationToken = default)
        {
            if (GetCurrentState() is not LoginState.AwaitingLogin)
            {
                _logger.Warning("Skipping AsBotAsync because state is not AwaitingLogin");
                return null;
            }

            var auth = await _client.Api.CloudChatsApi.Auth.ImportBotAuthorizationAsync(0, _clientSettings.ApiSettings.ApiId, _clientSettings.ApiSettings.ApiHash, token, cancellationToken: cancellationToken);
            if (auth.RpcCallFailed)
            {
                SetCurrentState(LoginState.AwaitingLogin);
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

            _sessionData.Authorization.SetAuthorized(LoginState.LoggedIn, auth.ExecutionInfo.ExecutedBy.DcId, castedUser.Id);
            _logger.Information("Successfully logged in as @{BotUsername}", castedUser.Username);
            SetCurrentState(LoginState.LoggedIn);
            return null;
        }

        public async Task<RpcError?> UseLoginCodeAsync(string loginCode, CancellationToken cancellationToken = default)
        {
            if (GetCurrentState() is not LoginState.AwaitingCode || _phoneData is null)
            {
                _logger.Warning("Skipping UseLoginCodeAsync because state is not AwaitingLogin");
                return null;
            }

            _logger.Information("Trying to sign-in using code {Code}", loginCode);
            var query = await _client.Api.CloudChatsApi.Auth.SignInAsync(_phoneData.PhoneNumber, _phoneData.PhoneHash, loginCode, cancellationToken: cancellationToken);
            if (query.RpcCallFailed)
            {
                if (query.Error.ErrorMessage == "SESSION_PASSWORD_NEEDED")
                {
                    var fetchResult = await FetchPasswordConfigAsync(cancellationToken);
                    if (fetchResult is null)
                    {
                        SetCurrentState(LoginState.AwaitingPassword);
                    }

                    return fetchResult;
                }

                SetCurrentState(LoginState.AwaitingLogin);
                return query.Error;
            }

            switch (query.Response)
            {
                case TL.Schemas.CloudChats.Auth.Authorization authorization when authorization.User is User user:
                    _logger.Information("Successfully logged in as user {User}", user.ToJson());
                    _sessionData.Authorization.SetAuthorized(LoginState.LoggedIn, query.ExecutionInfo.ExecutedBy.DcId, authorization.User.Id);
                    SetCurrentState(LoginState.LoggedIn);
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
                _logger.Warning("Skipping ResendCodeAsync because state is not AwaitingLogin");
                return null;
            }

            var r = await _client.Api.CloudChatsApi.Auth.ResendCodeAsync(_phoneData.PhoneNumber, _phoneData.PhoneHash);
            if (r.RpcCallFailed)
            {
                return r.Error;
            }

            _phoneData.SentCodeType = r.Response.Type;
            _phoneData.NextCodeType = r.Response.NextType;
            _phoneData.PhoneHash = r.Response.PhoneCodeHash;
            return null;
        }

        public async Task<RpcError?> UseProfileDataAsync(string firstName, string lastName, CancellationToken cancellationToken = default)
        {
            if(GetCurrentState() is not LoginState.AwaitingRegistration || _phoneData is null)
            {
                _logger.Warning("Skipping RegisterUserAsync because state is not AwaitingRegistration");
                return null;
            }

            var rpcQuery = await _client.Api.CloudChatsApi.Auth.SignUpAsync(_phoneData.PhoneNumber, _phoneData.PhoneHash, firstName, lastName, cancellationToken: cancellationToken);
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

            _logger.Information("Successfully registered user {User}", castedUser.ToJson());
            _sessionData.Authorization.SetAuthorized(LoginState.LoggedIn, rpcQuery.ExecutionInfo.ExecutedBy.DcId, castedUser.Id);
            SetCurrentState(LoginState.LoggedIn);
            return null;
        }

        public async Task<RpcError?> UsePasswordAsync(string password, CancellationToken cancellationToken = default)
        {
            if (GetCurrentState() is not LoginState.AwaitingPassword || _passwordAuthenticator is null)
            {
                _logger.Warning("Skipping UsePasswordAsync because state is not AwaitingLogin");
                return null;
            }

            var computedSrp = _passwordAuthenticator.CheckPassword(Encoding.UTF8.GetBytes(password));
            if (computedSrp.RpcCallFailed)
            {
                SetCurrentState(LoginState.AwaitingLogin);
                return computedSrp.Error;
            }

            var checkPasswordResult = await _client.Api.CloudChatsApi.Auth.CheckPasswordAsync(computedSrp.Response, cancellationToken: cancellationToken);
            if (checkPasswordResult.RpcCallFailed)
            {
                if (checkPasswordResult.Error.ErrorMessage == "PASSWORD_HASH_INVALID")
                {
                    _logger.Information("Provided password is not correct");
                    return new PasswordIncorrectError();
                }

                if (checkPasswordResult.Error.ErrorMessage == "SRP_ID_INVALID")
                {
                    _logger.Information("SRP token has expired, refetching data and retrying request...");
                    var fetchResult = await FetchPasswordConfigAsync(cancellationToken: cancellationToken);
                    if (fetchResult is not null)
                    {
                        SetCurrentState(LoginState.AwaitingLogin);
                        return fetchResult;
                    }

                    return await UsePasswordAsync(password, cancellationToken);
                }

                if (checkPasswordResult.Error is FloodWaitError floodWait)
                {
                    _logger.Information("A wait of {Time} seconds is required before trying another password", floodWait.WaitTime.TotalSeconds);
                    return checkPasswordResult.Error;
                }

                _logger.Error("An error occurred while checking password. Logging out... Error: {Error}", checkPasswordResult.Error);
                var logOut = await _client.Api.CloudChatsApi.Auth.LogOutAsync(cancellationToken: cancellationToken);
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

            _sessionData.Authorization.SetAuthorized(LoginState.LoggedIn, checkPasswordResult.ExecutionInfo.ExecutedBy.DcId, authorization.User.Id);
            _logger.Information("Successfully logged in as user {User}", castedUser.ToJson());
            SetCurrentState(LoginState.LoggedIn);
            return null;
        }

        public async Task<RpcError?> SetTermsAsync(bool accept, CancellationToken cancellationToken = default)
        {
            if (GetCurrentState() is not LoginState.AwaitingTermsAcceptance || _termsOfService is null)
            {
                _logger.Warning("Skipping SetTermsAsync because state is not AwaitingTermsAcceptance");
                return null;
            }

            if (accept)
            {
                SetCurrentState(LoginState.AwaitingRegistration);
            }
            else
            {
                _logger.Information("Terms of service declined, logging out...");
                var logOut = await _client.Api.CloudChatsApi.Auth.LogOutAsync(cancellationToken: cancellationToken);
                if (logOut.RpcCallFailed)
                {
                    _logger.Error("Could not log out due to error: {Error}", logOut);
                }

                SetCurrentState(LoginState.AwaitingLogin);
            }

            return null;
        }

        public async Task<RpcError?> LogoutAsync(CancellationToken token = default)
        {
            if (GetCurrentState() is not LoginState.AwaitingLogin)
            {
                _logger.Warning("Skipping LogoutAsync because state is not AwaitingLogin");
                return null;
            }

            var req = await _client.Api.CloudChatsApi.Auth.LogOutAsync(cancellationToken: token);
            if (req.RpcCallFailed)
            {
                return req.Error;
            }

            SetCurrentState(LoginState.LoggedOut);
            return null;
        }

        public (SentCodeTypeBase codeType, CodeTypeBase? nextCodeType)? GetCodeTypes()
        {
            if (GetCurrentState() is not LoginState.AwaitingCode || _phoneData is null)
            {
                _logger.Warning("Skipping GetCodeTypes because state is not AwaitingCode");
                return null;
            }

            return (_phoneData.SentCodeType, _phoneData.NextCodeType);
        }

        public TermsOfService? GetTermsOfService()
        {
            if (GetCurrentState() is not LoginState.AwaitingTermsAcceptance || _termsOfService is null)
            {
                _logger.Warning("Skipping DeclineTermsAsync because state is not AwaitingTermsAcceptance");
                return null;
            }

            return (TermsOfService?)_termsOfService.Clone();
        }

        public string? GetPasswordHint()
        {
            if (GetCurrentState() is not LoginState.AwaitingPassword)
            {
                _logger.Warning("Skipping GetPasswordHint because state is not AwaitingPassword");
                return null;
            }

            return _passwordHint;
        }

        private async Task<RpcError?> FetchPasswordConfigAsync(CancellationToken cancellationToken)
        {
            _logger.Information("Account is protected by 2FA password, fetching password data...");
            var passwordData = await _client.Api.CloudChatsApi.Account.GetPasswordAsync(cancellationToken: cancellationToken);
            if (passwordData.RpcCallFailed)
            {
                SetCurrentState(LoginState.AwaitingLogin);
                return passwordData.Error;
            }

            _passwordAuthenticator = new PasswordAuthenticator((Password)passwordData.Response, _logger);
            _passwordHint = ((Password)passwordData.Response).Hint;
            return null;
        }

        private void SetCurrentState(LoginState newState)
        {
            lock (_stateMutex)
            {
                _currentState = newState;
                var ev = _client.EventHandler;
                if(ev is not null)
                {
                    _sequentialInvoker.Invoke(() => ev.OnSessionUpdateAsync(newState));
                }

                // Won't save other states because they might not be valid and most of them require AwaitingLogin to be sent, if the client saves at the wrong time things could go wrong
                if(_currentState is LoginState.KeyDuplicated or LoginState.AwaitingLogin)
                {
                    _sessionData.Authorization.SetAuthorized(_currentState, null, null);
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
                else if(error.ErrorMessage == "AUTH_KEY_DROP_DUPLICATED")
                {
                    SetCurrentState(LoginState.KeyDuplicated);
                }
                else if(error.ErrorMessage == "ACCOUNT_BANNED")
                {
                    SetCurrentState(LoginState.AccountBanned);
                }
                else if(error.ErrorMessage == "USER_DEACTIVATED")
                {
                    SetCurrentState(LoginState.AccountDeactivated);
                }
                else if(error.ErrorMessage == "SESSION_EXPIRED")
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
