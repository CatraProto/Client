using System.IO;
using System.Text;
using CatraProto.Client.Extensions;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Rpc
{
    static class RpcReadingTools
    {
        public static bool GetRpcMessageResponseId(byte[] array, out int messageId)
        {
            var message = array.ToMemoryStream();
            using var binaryReader = new BinaryReader(message, Encoding.Default);
            if (binaryReader.ReadInt32() == RpcResult.ConstructorId)
            {
                messageId = binaryReader.ReadInt32();
                return true;
            }
            
            messageId = 0;
            return false;
        }
        
        public static bool IsRpcError(byte[] array, out RpcError error)
        {
            var stream = array.ToMemoryStream();
            using var reader = new Reader(MergedProvider.DefaultInstance, stream);
            if (reader.Read<int>() == RpcError.ConstructorId)
            {
                error = reader.Read<RpcError>();
                return true;
            }

            error = null;
            return false;
        }
    }
}