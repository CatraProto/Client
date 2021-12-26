namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler
{
    public class AuthKeyObject
    {
        public byte[] KeyArray { get; }
        public long AuthKeyId { get; }
        public long ServerSalt { get; }
        public int? ExpiresAt { get; }
        public AuthKeyObject(byte[] keyArray, long authKeyId, long serverSalt, int? expiresAt)
        {
            KeyArray = keyArray;
            AuthKeyId = authKeyId;
            ServerSalt = serverSalt;
            ExpiresAt = expiresAt;
        }
    }
}