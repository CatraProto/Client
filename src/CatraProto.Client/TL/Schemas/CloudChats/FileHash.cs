using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class FileHash : CatraProto.Client.TL.Schemas.CloudChats.FileHashBase
    {
        public static int StaticConstructorId
        {
            get => 1648543603;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public sealed override int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public sealed override byte[] Hash { get; set; }


    #nullable enable
        public FileHash(int offset, int limit, byte[] hash)
        {
            Offset = offset;
            Limit = limit;
            Hash = hash;
        }
    #nullable disable
        internal FileHash()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Offset);
            writer.Write(Limit);
            writer.Write(Hash);
        }

        public override void Deserialize(Reader reader)
        {
            Offset = reader.Read<int>();
            Limit = reader.Read<int>();
            Hash = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "fileHash";
        }
    }
}