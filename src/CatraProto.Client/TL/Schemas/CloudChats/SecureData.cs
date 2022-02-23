using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureData : CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase
    {
        public static int StaticConstructorId
        {
            get => -1964327229;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("data")] public sealed override byte[] Data { get; set; }

        [Newtonsoft.Json.JsonProperty("data_hash")]
        public sealed override byte[] DataHash { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public sealed override byte[] Secret { get; set; }


    #nullable enable
        public SecureData(byte[] data, byte[] dataHash, byte[] secret)
        {
            Data = data;
            DataHash = dataHash;
            Secret = secret;
        }
    #nullable disable
        internal SecureData()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Data);
            writer.Write(DataHash);
            writer.Write(Secret);
        }

        public override void Deserialize(Reader reader)
        {
            Data = reader.Read<byte[]>();
            DataHash = reader.Read<byte[]>();
            Secret = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "secureData";
        }
    }
}