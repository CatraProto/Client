using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateUserStatus : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -440534818; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }


#nullable enable
        public UpdateUserStatus(long userId, CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase status)
        {
            UserId = userId;
            Status = status;

        }
#nullable disable
        internal UpdateUserStatus()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            var checkstatus = writer.WriteObject(Status);
            if (checkstatus.IsError)
            {
                return checkstatus;
            }

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
            var trystatus = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase>();
            if (trystatus.IsError)
            {
                return ReadResult<IObject>.Move(trystatus);
            }
            Status = trystatus.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateUserStatus";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}