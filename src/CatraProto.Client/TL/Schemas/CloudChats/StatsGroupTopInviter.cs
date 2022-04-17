using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StatsGroupTopInviter : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopInviterBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1398765469; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("invitations")]
        public sealed override int Invitations { get; set; }


#nullable enable
        public StatsGroupTopInviter(long userId, int invitations)
        {
            UserId = userId;
            Invitations = invitations;

        }
#nullable disable
        internal StatsGroupTopInviter()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Invitations);

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
            var tryinvitations = reader.ReadInt32();
            if (tryinvitations.IsError)
            {
                return ReadResult<IObject>.Move(tryinvitations);
            }
            Invitations = tryinvitations.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "statsGroupTopInviter";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}