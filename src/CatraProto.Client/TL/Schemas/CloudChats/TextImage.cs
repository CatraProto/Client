using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TextImage : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        public static int StaticConstructorId
        {
            get => 136105807;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("document_id")]
        public long DocumentId { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }


    #nullable enable
        public TextImage(long documentId, int w, int h)
        {
            DocumentId = documentId;
            W = w;
            H = h;
        }
    #nullable disable
        internal TextImage()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(DocumentId);
            writer.Write(W);
            writer.Write(H);
        }

        public override void Deserialize(Reader reader)
        {
            DocumentId = reader.Read<long>();
            W = reader.Read<int>();
            H = reader.Read<int>();
        }

        public override string ToString()
        {
            return "textImage";
        }
    }
}