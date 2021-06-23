using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class SaveTheme : IMethod
    {
        public static int ConstructorId { get; } = -229175188;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public InputThemeBase Theme { get; set; }
        public bool Unsave { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Theme);
            writer.Write(Unsave);
        }

        public void Deserialize(Reader reader)
        {
            Theme = reader.Read<InputThemeBase>();
            Unsave = reader.Read<bool>();
        }
    }
}