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
    public partial class TextUrl : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1009288385; }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("webpage_id")]
        public long WebpageId { get; set; }


#nullable enable
        public TextUrl(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text, string url, long webpageId)
        {
            Text = text;
            Url = url;
            WebpageId = webpageId;
        }
#nullable disable
        internal TextUrl()
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

            writer.WriteString(Url);
            writer.WriteInt64(WebpageId);

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
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            var trywebpageId = reader.ReadInt64();
            if (trywebpageId.IsError)
            {
                return ReadResult<IObject>.Move(trywebpageId);
            }

            WebpageId = trywebpageId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "textUrl";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextUrl();
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }

            newClonedObject.Text = cloneText;
            newClonedObject.Url = Url;
            newClonedObject.WebpageId = WebpageId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TextUrl castedOther)
            {
                return true;
            }

            if (Text.Compare(castedOther.Text))
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (WebpageId != castedOther.WebpageId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}