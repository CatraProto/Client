using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class GetThemes : IMethod
    {
        public static int ConstructorId { get; } = 676939512;

        public Type Type { get; init; } = typeof(ThemesBase);
        public bool IsVector { get; init; } = false;
        public string Format { get; set; }
        public int Hash { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

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