using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UrlAuthResultAccepted : CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase
    {
        public static int StaticConstructorId
        {
            get => -1886646706;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }


    #nullable enable
        public UrlAuthResultAccepted(string url)
        {
            Url = url;
        }
    #nullable disable
        internal UrlAuthResultAccepted()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Url);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
        }

        public override string ToString()
        {
            return "urlAuthResultAccepted";
        }
    }
}