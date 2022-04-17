using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputDocument : CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 448771445; }

        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }

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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);

            writer.WriteBytes(FileReference);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }
            AccessHash = tryaccessHash.Value;
            var tryfileReference = reader.ReadBytes();
            if (tryfileReference.IsError)
            {
                return ReadResult<IObject>.Move(tryfileReference);
            }
            FileReference = tryfileReference.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputDocument";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}