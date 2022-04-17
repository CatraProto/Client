using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ExportedMessageLink : CatraProto.Client.TL.Schemas.CloudChats.ExportedMessageLinkBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1571494644; }

        [Newtonsoft.Json.JsonProperty("link")]
        public sealed override string Link { get; set; }

        [Newtonsoft.Json.JsonProperty("html")]
        public sealed override string Html { get; set; }


#nullable enable
        public ExportedMessageLink(string link, string html)
        {
            Link = link;
            Html = html;

        }
#nullable disable
        internal ExportedMessageLink()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Link);

            writer.WriteString(Html);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylink = reader.ReadString();
            if (trylink.IsError)
            {
                return ReadResult<IObject>.Move(trylink);
            }
            Link = trylink.Value;
            var tryhtml = reader.ReadString();
            if (tryhtml.IsError)
            {
                return ReadResult<IObject>.Move(tryhtml);
            }
            Html = tryhtml.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "exportedMessageLink";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}