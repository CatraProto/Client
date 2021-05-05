using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetThemes : IMethod<ThemesBase>
    {
        public static int ConstructorId { get; } = 676939512;
        public string Format { get; set; }
        public int Hash { get; set; }

        public Type Type { get; init; } = typeof(GetThemes);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Format);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Format = reader.Read<string>();
            Hash = reader.Read<int>();
        }
    }
}