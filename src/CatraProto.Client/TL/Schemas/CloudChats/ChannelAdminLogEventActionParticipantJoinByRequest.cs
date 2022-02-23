using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionParticipantJoinByRequest : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => -1347021750;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

        [Newtonsoft.Json.JsonProperty("approved_by")]
        public long ApprovedBy { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionParticipantJoinByRequest(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite, long approvedBy)
        {
            Invite = invite;
            ApprovedBy = approvedBy;
        }
    #nullable disable
        internal ChannelAdminLogEventActionParticipantJoinByRequest()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Invite);
            writer.Write(ApprovedBy);
        }

        public override void Deserialize(Reader reader)
        {
            Invite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            ApprovedBy = reader.Read<long>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionParticipantJoinByRequest";
        }
    }
}