using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureFile : CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -534283678; }

        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("size")]
        public int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("file_hash")]
        public byte[] FileHash { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public byte[] Secret { get; set; }


#nullable enable
        public SecureFile(long id, long accessHash, int size, int dcId, int date, byte[] fileHash, byte[] secret)
        {
            Id = id;
            AccessHash = accessHash;
            Size = size;
            DcId = dcId;
            Date = date;
            FileHash = fileHash;
            Secret = secret;

        }
#nullable disable
        internal SecureFile()
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
            writer.WriteInt32(Size);
            writer.WriteInt32(DcId);
            writer.WriteInt32(Date);

            writer.WriteBytes(FileHash);

            writer.WriteBytes(Secret);

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
            var trysize = reader.ReadInt32();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }
            Size = trysize.Value;
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }
            DcId = trydcId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryfileHash = reader.ReadBytes();
            if (tryfileHash.IsError)
            {
                return ReadResult<IObject>.Move(tryfileHash);
            }
            FileHash = tryfileHash.Value;
            var trysecret = reader.ReadBytes();
            if (trysecret.IsError)
            {
                return ReadResult<IObject>.Move(trysecret);
            }
            Secret = trysecret.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "secureFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureFile
            {
                Id = Id,
                AccessHash = AccessHash,
                Size = Size,
                DcId = DcId,
                Date = Date,
                FileHash = FileHash,
                Secret = Secret
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureFile castedOther)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }
            if (Size != castedOther.Size)
            {
                return true;
            }
            if (DcId != castedOther.DcId)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            if (FileHash != castedOther.FileHash)
            {
                return true;
            }
            if (Secret != castedOther.Secret)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}