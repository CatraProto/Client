using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatraProto.Client.MTProto.Rpc.Interfaces;

namespace CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors
{
    public class MissingRequestError : RpcError
    {
        public override string ErrorDescription { get; }

        public MissingRequestError() : base("The request was not found", -10404)
        {
        }
    }
}
