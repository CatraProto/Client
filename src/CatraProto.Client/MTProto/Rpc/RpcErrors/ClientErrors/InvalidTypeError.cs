using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors
{
    public class InvalidTypeError : RpcError
    {
        public override string ErrorDescription { get; } = "Invalid type specified";

        public InvalidTypeError() : base("INVALID_TYPE_ERROR", -10400)
        {
        }
    }
}
