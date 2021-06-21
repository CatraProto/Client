using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InvokeAfterMsgs : IMethod
    {
        public static int ConstructorId { get; } = 1036301552;
        public IList<long> MsgIds { get; set; }
        public IObject Query { get; set; }

        public Type Type { get; init; } = typeof(IObject);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
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