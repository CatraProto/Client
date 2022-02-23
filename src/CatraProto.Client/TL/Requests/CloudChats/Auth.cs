using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Account;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using AuthorizationBase = CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public partial class Auth
    {
        private readonly MessagesQueue _messagesQueue;
        private readonly TelegramClient _client;

        internal Auth(TelegramClient client, MessagesQueue messagesQueue)
        {
            _client = client;
            _messagesQueue = messagesQueue;
        }

        public async Task<RpcMessage<SentCodeBase>> SendCodeAsync(string phoneNumber, int apiId, string apiHash, CodeSettingsBase settings, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SentCodeBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SendCode
            {
                PhoneNumber = phoneNumber,
                ApiId = apiId,
                ApiHash = apiHash,
                Settings = settings
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AuthorizationBase>> SignUpAsync(string phoneNumber, string phoneCodeHash, string firstName, string lastName, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AuthorizationBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SignUp
            {
                PhoneNumber = phoneNumber,
                PhoneCodeHash = phoneCodeHash,
                FirstName = firstName,
                LastName = lastName
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AuthorizationBase>> SignInAsync(string phoneNumber, string phoneCodeHash, string phoneCode, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AuthorizationBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new SignIn
            {
                PhoneNumber = phoneNumber,
                PhoneCodeHash = phoneCodeHash,
                PhoneCode = phoneCode
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<LoggedOutBase>> LogOutAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LoggedOutBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new LogOut();

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ResetAuthorizationsAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ResetAuthorizations();

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<ExportedAuthorizationBase>> ExportAuthorizationAsync(int dcId, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ExportedAuthorizationBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ExportAuthorization
            {
                DcId = dcId
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AuthorizationBase>> ImportAuthorizationAsync(long id, byte[] bytes, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AuthorizationBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ImportAuthorization
            {
                Id = id,
                Bytes = bytes
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> BindTempAuthKeyAsync(long permAuthKeyId, long nonce, int expiresAt, byte[] encryptedMessage, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new BindTempAuthKey
            {
                PermAuthKeyId = permAuthKeyId,
                Nonce = nonce,
                ExpiresAt = expiresAt,
                EncryptedMessage = encryptedMessage
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AuthorizationBase>> ImportBotAuthorizationAsync(int flags, int apiId, string apiHash, string botAuthToken, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AuthorizationBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ImportBotAuthorization
            {
                Flags = flags,
                ApiId = apiId,
                ApiHash = apiHash,
                BotAuthToken = botAuthToken
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AuthorizationBase>> CheckPasswordAsync(InputCheckPasswordSRPBase password, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AuthorizationBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new CheckPassword
            {
                Password = password
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<PasswordRecoveryBase>> RequestPasswordRecoveryAsync(MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<PasswordRecoveryBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new RequestPasswordRecovery();

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<AuthorizationBase>> RecoverPasswordAsync(string code, PasswordInputSettingsBase? newSettings = null, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<AuthorizationBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new RecoverPassword
            {
                Code = code,
                NewSettings = newSettings
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<SentCodeBase>> ResendCodeAsync(string phoneNumber, string phoneCodeHash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SentCodeBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ResendCode
            {
                PhoneNumber = phoneNumber,
                PhoneCodeHash = phoneCodeHash
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> CancelCodeAsync(string phoneNumber, string phoneCodeHash, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new CancelCode
            {
                PhoneNumber = phoneNumber,
                PhoneCodeHash = phoneCodeHash
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> DropTempAuthKeysAsync(IList<long> exceptAuthKeys, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new DropTempAuthKeys
            {
                ExceptAuthKeys = exceptAuthKeys
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<LoginTokenBase>> ExportLoginTokenAsync(int apiId, string apiHash, IList<long> exceptIds, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LoginTokenBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ExportLoginToken
            {
                ApiId = apiId,
                ApiHash = apiHash,
                ExceptIds = exceptIds
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<LoginTokenBase>> ImportLoginTokenAsync(byte[] token, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<LoginTokenBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new ImportLoginToken
            {
                Token = token
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<Schemas.CloudChats.AuthorizationBase>> AcceptLoginTokenAsync(byte[] token, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<Schemas.CloudChats.AuthorizationBase>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new AcceptLoginToken
            {
                Token = token
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> CheckRecoveryPasswordAsync(string code, MessageSendingOptions? messageSendingOptions = null, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            messageSendingOptions ??= new MessageSendingOptions(isEncrypted: true);
            var methodBody = new CheckRecoveryPassword
            {
                Code = code
            };

            _messagesQueue.EnqueueMessage(methodBody, messageSendingOptions, rpcResponse, out var taskCompletionSource, cancellationToken);
            await taskCompletionSource!;
            return rpcResponse;
        }
    }
}