using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputUser : CatraProto.Client.TL.Schemas.CloudChats.InputUserBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -233744186; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }


#nullable enable
        public InputUser(long userId, long accessHash)
        {
            UserId = userId;
            AccessHash = accessHash;

        }
#nullable disable
        internal InputUser()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt64(AccessHash);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
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
            return "inputUser";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}