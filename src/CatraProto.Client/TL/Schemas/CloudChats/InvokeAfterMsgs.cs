using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InvokeAfterMsgs : IMethod
    {
        public static int ConstructorId { get; } = 1036301552;

        public System.Type Type { get; init; } = typeof(IObject);
        public bool IsVector { get; init; } = false;
        public IList<long> MsgIds { get; set; }
        public IObject Query { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(MsgIds);
            writer.Write(Query);
        }

        public void Deserialize(Reader reader)
        {
            MsgIds = reader.ReadVector<long>();
            Query = reader.Read<IObject>();
        }
    }
}