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
    public partial class PageListOrderedItemText : CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1577484359; }

        [Newtonsoft.Json.JsonProperty("num")] public sealed override string Num { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


#nullable enable
        public PageListOrderedItemText(string num, CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
        {
            Num = num;
            Text = text;
        }
#nullable disable
        internal PageListOrderedItemText()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Num);
            var checktext = writer.WriteObject(Text);
            if (checktext.IsError)
            {
                return checktext;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynum = reader.ReadString();
            if (trynum.IsError)
            {
                return ReadResult<IObject>.Move(trynum);
            }

            Num = trynum.Value;
            var trytext = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "pageListOrderedItemText";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PageListOrderedItemText();
            newClonedObject.Num = Num;
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }

            newClonedObject.Text = cloneText;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PageListOrderedItemText castedOther)
            {
                return true;
            }

            if (Num != castedOther.Num)
            {
                return true;
            }

            if (Text.Compare(castedOther.Text))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}