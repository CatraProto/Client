using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Search : IMethod<FoundBase>
    {
        public static int ConstructorId { get; } = 301470424;
        public string Q { get; set; }
        public int Limit { get; set; }

        public Type Type { get; init; } = typeof(Search);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Q);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Q = reader.Read<string>();
            Limit = reader.Read<int>();
        }
    }
}