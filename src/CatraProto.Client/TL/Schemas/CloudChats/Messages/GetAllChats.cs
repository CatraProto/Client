using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetAllChats : IMethod
    {
        public static int ConstructorId { get; } = -341307408;
        public IList<int> ExceptIds { get; set; }

        public Type Type { get; init; } = typeof(ChatsBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(ExceptIds);
        }

        public void Deserialize(Reader reader)
        {
            ExceptIds = reader.ReadVector<int>();
        }
    }
}