using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetStickerSet : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 639215886;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(StickerSetBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("stickerset")] public InputStickerSetBase Stickerset { get; set; }

        public override string ToString()
        {
            return "messages.getStickerSet";
        }


        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Stickerset);
        }

        public void Deserialize(Reader reader)
        {
            Stickerset = reader.Read<InputStickerSetBase>();
        }
    }
}