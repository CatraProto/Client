using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetAttachedStickers : IMethod
    {
        public static int ConstructorId { get; } = -866424884;
        public InputStickeredMediaBase Media { get; set; }

        public Type Type { get; init; } = typeof(StickerSetCoveredBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Media);
        }

        public void Deserialize(Reader reader)
        {
            Media = reader.Read<InputStickeredMediaBase>();
        }
    }
}