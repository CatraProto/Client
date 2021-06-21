using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class GetBlocked : IMethod
    {
        public static int ConstructorId { get; } = -176409329;
        public int Offset { get; set; }
        public int Limit { get; set; }

        public Type Type { get; init; } = typeof(BlockedBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Offset);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
        }
    }
}