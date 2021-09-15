using System;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class MessageEditData : MessageEditDataBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Caption = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 649453030;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("caption")] public override bool Caption { get; set; }


        public override void UpdateFlags()
        {
            Flags = Caption ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Caption = FlagsHelper.IsFlagSet(Flags, 0);
        }

        public override string ToString()
        {
            return "messages.messageEditData";
        }
    }
}