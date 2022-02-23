using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class GzipPacked : IObject
    {
        public static int StaticConstructorId
        {
            get => 812830625;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("packed_data")]
        public byte[] PackedData { get; set; }


    #nullable enable
        public GzipPacked(byte[] packedData)
        {
            PackedData = packedData;
        }
    #nullable disable
        internal GzipPacked()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(PackedData);
        }

        public void Deserialize(Reader reader)
        {
            PackedData = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "gzip_packed";
        }
    }
}