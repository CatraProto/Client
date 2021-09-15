using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ExportedAuthorization : ExportedAuthorizationBase
    {
        public static int StaticConstructorId
        {
            get => -543777747;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("id")] public override int Id { get; set; }

        [JsonProperty("bytes")] public override byte[] Bytes { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
            writer.Write(Bytes);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<int>();
            Bytes = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "auth.exportedAuthorization";
        }
    }
}