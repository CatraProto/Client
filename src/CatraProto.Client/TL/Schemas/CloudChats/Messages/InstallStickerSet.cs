using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class InstallStickerSet : IMethod
    {
        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -946871200;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(StickerSetInstallResultBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonProperty("stickerset")] public InputStickerSetBase Stickerset { get; set; }

        [JsonProperty("archived")] public bool Archived { get; set; }

        public override string ToString()
        {
            return "messages.installStickerSet";
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
            writer.Write(Archived);
        }

        public void Deserialize(Reader reader)
        {
            Stickerset = reader.Read<InputStickerSetBase>();
            Archived = reader.Read<bool>();
        }
    }
}