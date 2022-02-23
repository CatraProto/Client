using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class KeyboardButtonUrlAuth : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FwdText = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 280464681;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("fwd_text")]
        public string FwdText { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("button_id")]
        public int ButtonId { get; set; }


    #nullable enable
        public KeyboardButtonUrlAuth(string text, string url, int buttonId)
        {
            Text = text;
            Url = url;
            ButtonId = buttonId;
        }
    #nullable disable
        internal KeyboardButtonUrlAuth()
        {
        }

        public override void UpdateFlags()
        {
            Flags = FwdText == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Text);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(FwdText);
            }

            writer.Write(Url);
            writer.Write(ButtonId);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Text = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                FwdText = reader.Read<string>();
            }

            Url = reader.Read<string>();
            ButtonId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "keyboardButtonUrlAuth";
        }
    }
}