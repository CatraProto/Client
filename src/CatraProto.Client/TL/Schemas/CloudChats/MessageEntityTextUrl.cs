using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageEntityTextUrl : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
    {
        public static int StaticConstructorId
        {
            get => 1990644519;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public sealed override int Length { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }


    #nullable enable
        public MessageEntityTextUrl(int offset, int length, string url)
        {
            Offset = offset;
            Length = length;
            Url = url;
        }
    #nullable disable
        internal MessageEntityTextUrl()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Offset);
            writer.Write(Length);
            writer.Write(Url);
        }

        public override void Deserialize(Reader reader)
        {
            Offset = reader.Read<int>();
            Length = reader.Read<int>();
            Url = reader.Read<string>();
        }

        public override string ToString()
        {
            return "messageEntityTextUrl";
        }
    }
}