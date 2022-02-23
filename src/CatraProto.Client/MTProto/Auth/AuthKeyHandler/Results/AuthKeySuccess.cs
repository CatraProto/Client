namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler.Results
{
    class AuthKeySuccess : AuthKeyResult
    {
        public byte[] KeyArray { get; }
        public long AuthKeyId { get; }
        public long ServerSalt { get; }
        public int? ExpiresAt { get; }
        public AuthKeySuccess(byte[] keyArray, long authKeyId, long serverSalt, int? expiresAt)
        {
            KeyArray = keyArray;
            AuthKeyId = authKeyId;
            ServerSalt = serverSalt;
            ExpiresAt = expiresAt;
        }
    }
}