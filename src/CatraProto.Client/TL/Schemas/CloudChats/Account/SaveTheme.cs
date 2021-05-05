using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SaveTheme : IMethod<bool>
    {
        public static int ConstructorId { get; } = -229175188;
        public InputThemeBase Theme { get; set; }
        public bool Unsave { get; set; }

        public Type Type { get; init; } = typeof(SaveTheme);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
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