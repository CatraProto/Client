namespace CatraProto.Client.MTProto.AuthKeyHandler.Results
{
    class AuthKeySuccess : AuthKeyResult
    {
        public byte[] ServerSalt { get; init; }

        public AuthKeySuccess(byte[] serverSalt)
        {
            ServerSalt = serverSalt;
        }
    }
}