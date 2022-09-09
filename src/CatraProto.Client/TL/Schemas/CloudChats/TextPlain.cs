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
    public partial class TextPlain : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1950782688; }

        [Newtonsoft.Json.JsonProperty("text")] public string Text { get; set; }


#nullable enable
        public TextPlain(string text)
        {
            Text = text;
        }
#nullable disable
        internal TextPlain()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);

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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "textPlain";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextPlain();
            newClonedObject.Text = Text;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TextPlain castedOther)
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