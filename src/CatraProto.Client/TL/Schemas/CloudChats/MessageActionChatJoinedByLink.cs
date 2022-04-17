using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionChatJoinedByLink : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 51520707; }

        [Newtonsoft.Json.JsonProperty("inviter_id")]
        public long InviterId { get; set; }


#nullable enable
        public MessageActionChatJoinedByLink(long inviterId)
        {
            InviterId = inviterId;

        }
#nullable disable
        internal MessageActionChatJoinedByLink()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(InviterId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryinviterId = reader.ReadInt64();
            if (tryinviterId.IsError)
            {
                return ReadResult<IObject>.Move(tryinviterId);
            }
            InviterId = tryinviterId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionChatJoinedByLink";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}