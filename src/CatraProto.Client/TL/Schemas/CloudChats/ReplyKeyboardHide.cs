using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ReplyKeyboardHide : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Selective = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => -1606526075;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("selective")]
        public bool Selective { get; set; }


        public ReplyKeyboardHide()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Selective = FlagsHelper.IsFlagSet(Flags, 2);
        }

        public override string ToString()
        {
            return "replyKeyboardHide";
        }
    }
}