using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetAttachedStickers : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -866424884;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(StickerSetCoveredBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = true;

        [JsonProperty("media")] public InputStickeredMediaBase Media { get; set; }

        public override string ToString()
        {
            return "messages.getAttachedStickers";
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

            writer.Write(Media);
        }

        public void Deserialize(Reader reader)
        {
            Media = reader.Read<InputStickeredMediaBase>();
        }
    }
}