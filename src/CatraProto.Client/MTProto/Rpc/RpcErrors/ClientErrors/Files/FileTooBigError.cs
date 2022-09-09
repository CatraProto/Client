using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors.Files;

public class FileTooBigError : RpcError
{
    public override string ErrorDescription { get; }

    public FileTooBigError(string errorDescription = "The file you've tried to upload exceeds the maximum allowed size") : base("FILE_TOO_BIG", 413)
    {
        ErrorDescription = errorDescription;
    }
}