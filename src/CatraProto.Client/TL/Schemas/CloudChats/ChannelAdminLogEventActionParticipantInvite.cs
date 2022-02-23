using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionParticipantInvite : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => -484690728;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase Participant { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionParticipantInvite(CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase participant)
        {
            Participant = participant;
        }
    #nullable disable
        internal ChannelAdminLogEventActionParticipantInvite()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Participant);
        }

        public override void Deserialize(Reader reader)
        {
            Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionParticipantInvite";
        }
    }
}