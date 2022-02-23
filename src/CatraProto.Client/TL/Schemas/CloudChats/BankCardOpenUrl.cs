using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BankCardOpenUrl : CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase
    {
        public static int StaticConstructorId
        {
            get => -177732982;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("name")] public sealed override string Name { get; set; }


    #nullable enable
        public BankCardOpenUrl(string url, string name)
        {
            Url = url;
            Name = name;
        }
    #nullable disable
        internal BankCardOpenUrl()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Url);
            writer.Write(Name);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
            Name = reader.Read<string>();
        }

        public override string ToString()
        {
            return "bankCardOpenUrl";
        }
    }
}