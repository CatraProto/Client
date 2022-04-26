using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class FileHash : CatraProto.Client.TL.Schemas.CloudChats.FileHashBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1648543603; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public sealed override int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public sealed override byte[] Hash { get; set; }


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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Offset);
            writer.WriteInt32(Limit);

            writer.WriteBytes(Hash);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }
            Limit = trylimit.Value;
            var tryhash = reader.ReadBytes();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "fileHash";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FileHash
            {
                Offset = Offset,
                Limit = Limit,
                Hash = Hash
            };
            return newClonedObject;

        }
#nullable disable
    }
}