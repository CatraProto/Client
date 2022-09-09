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
    public partial class TextAnchor : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 894777186; }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public string Name { get; set; }


#nullable enable
        public TextAnchor(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text, string name)
        {
            Text = text;
            Name = name;
        }
#nullable disable
        internal TextAnchor()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktext = writer.WriteObject(Text);
            if (checktext.IsError)
            {
                return checktext;
            }

            writer.WriteString(Name);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            var tryname = reader.ReadString();
            if (tryname.IsError)
            {
                return ReadResult<IObject>.Move(tryname);
            }

            Name = tryname.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "textAnchor";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextAnchor();
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }

            newClonedObject.Text = cloneText;
            newClonedObject.Name = Name;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TextAnchor castedOther)
            {
                return true;
            }

            if (Text.Compare(castedOther.Text))
            {
                return true;
            }

            if (Name != castedOther.Name)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}