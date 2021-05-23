using System;
using System.IO;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Connections
{
    public class RpcReader
    {
        public long MessageId { get; set; }
        public object Response { get; set; }

        public void ReadObject(IMethod method, Reader reader)
        {
            Response = method.IsVector ? reader.ReadVector(method.Type) : reader.Read(method.Type);
        }
    }
}