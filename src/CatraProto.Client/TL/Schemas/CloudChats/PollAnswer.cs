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
    public partial class PollAnswer : CatraProto.Client.TL.Schemas.CloudChats.PollAnswerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1823064809; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("option")]
        public sealed override byte[] Option { get; set; }


#nullable enable
        public PollAnswer(string text, byte[] option)
        {
            Text = text;
            Option = option;
        }
#nullable disable
        internal PollAnswer()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);

            writer.WriteBytes(Option);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            var tryoption = reader.ReadBytes();
            if (tryoption.IsError)
            {
                return ReadResult<IObject>.Move(tryoption);
            }

            Option = tryoption.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pollAnswer";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PollAnswer();
            newClonedObject.Text = Text;
            newClonedObject.Option = Option;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PollAnswer castedOther)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (Option != castedOther.Option)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}