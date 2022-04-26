using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPhotoFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1075322878; }

        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("file_reference")]
        public byte[] FileReference { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb_size")]
        public string ThumbSize { get; set; }


#nullable enable
        public InputPhotoFileLocation(long id, long accessHash, byte[] fileReference, string thumbSize)
        {
            Id = id;
            AccessHash = accessHash;
            FileReference = fileReference;
            ThumbSize = thumbSize;

        }
#nullable disable
        internal InputPhotoFileLocation()
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

            writer.WriteString(ThumbSize);

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
            var trythumbSize = reader.ReadString();
            if (trythumbSize.IsError)
            {
                return ReadResult<IObject>.Move(trythumbSize);
            }
            ThumbSize = trythumbSize.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputPhotoFileLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPhotoFileLocation
            {
                Id = Id,
                AccessHash = AccessHash,
                FileReference = FileReference,
                ThumbSize = ThumbSize
            };
            return newClonedObject;

        }
#nullable disable
    }
}