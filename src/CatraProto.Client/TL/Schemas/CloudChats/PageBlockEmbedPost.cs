using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockEmbedPost : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -229005301; }

        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("webpage_id")]
        public long WebpageId { get; set; }

        [Newtonsoft.Json.JsonProperty("author_photo_id")]
        public long AuthorPhotoId { get; set; }

        [Newtonsoft.Json.JsonProperty("author")]
        public string Author { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("blocks")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


#nullable enable
        public PageBlockEmbedPost(string url, long webpageId, long authorPhotoId, string author, int date, List<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks, CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
        {
            Url = url;
            WebpageId = webpageId;
            AuthorPhotoId = authorPhotoId;
            Author = author;
            Date = date;
            Blocks = blocks;
            Caption = caption;

        }
#nullable disable
        internal PageBlockEmbedPost()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            writer.WriteInt64(WebpageId);
            writer.WriteInt64(AuthorPhotoId);

            writer.WriteString(Author);
            writer.WriteInt32(Date);
            var checkblocks = writer.WriteVector(Blocks, false);
            if (checkblocks.IsError)
            {
                return checkblocks;
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
            var tryauthorPhotoId = reader.ReadInt64();
            if (tryauthorPhotoId.IsError)
            {
                return ReadResult<IObject>.Move(tryauthorPhotoId);
            }
            AuthorPhotoId = tryauthorPhotoId.Value;
            var tryauthor = reader.ReadString();
            if (tryauthor.IsError)
            {
                return ReadResult<IObject>.Move(tryauthor);
            }
            Author = tryauthor.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryblocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryblocks.IsError)
            {
                return ReadResult<IObject>.Move(tryblocks);
            }
            Blocks = tryblocks.Value;
            var trycaption = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();
            if (trycaption.IsError)
            {
                return ReadResult<IObject>.Move(trycaption);
            }
            Caption = trycaption.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "pageBlockEmbedPost";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}