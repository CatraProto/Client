using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputWallPaper : CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -433014407; }

        [Newtonsoft.Json.JsonProperty("id")]
        public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }


#nullable enable
        public InputWallPaper(long id, long accessHash)
        {
            Id = id;
            AccessHash = accessHash;

        }
#nullable disable
        internal InputWallPaper()
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
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputWallPaper";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputWallPaper
            {
                Id = Id,
                AccessHash = AccessHash
            };
            return newClonedObject;

        }
#nullable disable
    }
}