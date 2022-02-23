using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputDocument : CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase
    {
        public static int StaticConstructorId
        {
            get => 448771445;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("file_reference")]
        public byte[] FileReference { get; set; }


    #nullable enable
        public InputDocument(long id, long accessHash, byte[] fileReference)
        {
            Id = id;
            AccessHash = accessHash;
            FileReference = fileReference;
        }
    #nullable disable
        internal InputDocument()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(AccessHash);
            writer.Write(FileReference);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            AccessHash = reader.Read<long>();
            FileReference = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "inputDocument";
        }
    }
}