using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionParticipantMute : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {
        public static int StaticConstructorId
        {
            get => -115071790;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase Participant { get; set; }


    #nullable enable
        public ChannelAdminLogEventActionParticipantMute(CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase participant)
        {
            Participant = participant;
        }
    #nullable disable
        internal ChannelAdminLogEventActionParticipantMute()
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
            Participant = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GroupCallParticipantBase>();
        }

        public override string ToString()
        {
            return "channelAdminLogEventActionParticipantMute";
        }
    }
}