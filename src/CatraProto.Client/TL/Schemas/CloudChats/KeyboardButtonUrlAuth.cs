using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 280464681; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

        [MaybeNull]
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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Text);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(FwdText);
            }


            writer.WriteString(Url);
            writer.WriteInt32(ButtonId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfwdText = reader.ReadString();
                if (tryfwdText.IsError)
                {
                    return ReadResult<IObject>.Move(tryfwdText);
                }

                FwdText = tryfwdText.Value;
            }

            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            var trybuttonId = reader.ReadInt32();
            if (trybuttonId.IsError)
            {
                return ReadResult<IObject>.Move(trybuttonId);
            }

            ButtonId = trybuttonId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "keyboardButtonUrlAuth";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new KeyboardButtonUrlAuth();
            newClonedObject.Flags = Flags;
            newClonedObject.Text = Text;
            newClonedObject.FwdText = FwdText;
            newClonedObject.Url = Url;
            newClonedObject.ButtonId = ButtonId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not KeyboardButtonUrlAuth castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (FwdText != castedOther.FwdText)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (ButtonId != castedOther.ButtonId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}