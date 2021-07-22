using CatraProto.TL;

namespace CatraProto.Client.MTProto.Rpc
{
    interface IRpcMessage
    {
        public void SetResponse(object o);
    }
}