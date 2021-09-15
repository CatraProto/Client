using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SaveRecentSticker : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Attached = 1 << 0
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => 958863608;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("attached")] public bool Attached { get; set; }

        [JsonProperty("id")] public InputDocumentBase Id { get; set; }

        [JsonProperty("unsave")] public bool Unsave { get; set; }

        public override string ToString()
        {
            return "messages.saveRecentSticker";
        }


        public void UpdateFlags()
        {
            Flags = Attached ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            writer.Write(Unsave);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Attached = FlagsHelper.IsFlagSet(Flags, 0);
            Id = reader.Read<InputDocumentBase>();
            Unsave = reader.Read<bool>();
        }
    }
}