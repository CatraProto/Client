using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class ExportedAuthorization : CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase
    {
        public static int StaticConstructorId
        {
            get => -1271602504;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override byte[] Bytes { get; set; }


    #nullable enable
        public ExportedAuthorization(long id, byte[] bytes)
        {
            Id = id;
            Bytes = bytes;
        }
    #nullable disable
        internal ExportedAuthorization()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Bytes);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Bytes = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "auth.exportedAuthorization";
        }
    }
}