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
    public partial class PageBlockBlockquote : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 641563686; }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Caption { get; set; }


#nullable enable
        public PageBlockBlockquote(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text, CatraProto.Client.TL.Schemas.CloudChats.RichTextBase caption)
        {
            Text = text;
            Caption = caption;
        }
#nullable disable
        internal PageBlockBlockquote()
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

            var checkcaption = writer.WriteObject(Caption);
            if (checkcaption.IsError)
            {
                return checkcaption;
            }

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
            var trycaption = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trycaption.IsError)
            {
                return ReadResult<IObject>.Move(trycaption);
            }

            Caption = trycaption.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageBlockBlockquote";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageBlockBlockquote();
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }

            newClonedObject.Text = cloneText;
            var cloneCaption = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Caption.Clone();
            if (cloneCaption is null)
            {
                return null;
            }

            newClonedObject.Caption = cloneCaption;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageBlockBlockquote castedOther)
            {
                return true;
            }

            if (Text.Compare(castedOther.Text))
            {
                return true;
            }

            if (Caption.Compare(castedOther.Caption))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}