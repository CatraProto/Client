using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class GzipPacked : IObject
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 812830625; }

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

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(PackedData);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypackedData = reader.ReadBytes();
            if (trypackedData.IsError)
            {
                return ReadResult<IObject>.Move(trypackedData);
            }
            PackedData = trypackedData.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "gzip_packed";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}