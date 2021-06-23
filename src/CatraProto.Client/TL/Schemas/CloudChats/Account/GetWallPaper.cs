using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class GetWallPaper : IMethod
    {
        public static int ConstructorId { get; } = -57811990;

        public Type Type { get; init; } = typeof(WallPaperBase);
        public bool IsVector { get; init; } = false;
        public InputWallPaperBase Wallpaper { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Wallpaper);
        }

        public void Deserialize(Reader reader)
        {
            Wallpaper = reader.Read<InputWallPaperBase>();
        }
    }
}