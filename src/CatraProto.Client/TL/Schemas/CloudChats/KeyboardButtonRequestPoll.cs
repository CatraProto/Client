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
    public partial class KeyboardButtonRequestPoll : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Quiz = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1144565411; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("quiz")] public bool? Quiz { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }


#nullable enable
        public KeyboardButtonRequestPoll(string text)
        {
            Text = text;
        }
#nullable disable
        internal KeyboardButtonRequestPoll()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Quiz == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkquiz = writer.WriteBool(Quiz.Value);
                if (checkquiz.IsError)
                {
                    return checkquiz;
                }
            }


            writer.WriteString(Text);

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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryquiz = reader.ReadBool();
                if (tryquiz.IsError)
                {
                    return ReadResult<IObject>.Move(tryquiz);
                }

                Quiz = tryquiz.Value;
            }

            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "keyboardButtonRequestPoll";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new KeyboardButtonRequestPoll();
            newClonedObject.Flags = Flags;
            newClonedObject.Quiz = Quiz;
            newClonedObject.Text = Text;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not KeyboardButtonRequestPoll castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Quiz != castedOther.Quiz)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}