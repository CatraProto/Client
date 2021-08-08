namespace CatraProto.Client.MTProto.Auth.AuthKeyHandler.Results
{
    public enum Errors
    {
        UnexpectedError,
        NonceMismatch,
        ServerCallFail,
        RsaNotFound,
        ReqPqFail,
        ServerDhFail,
        DhGenFail,
        HashMismatch
    }

    class AuthKeyFail : AuthKeyResult
    {
        public Errors Error { get; init; }

        public AuthKeyFail(Errors error)
        {
            Error = error;
        }
    }
}