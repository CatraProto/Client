using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantToggleBan : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => -422036098; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_participant")]
		public ChannelParticipantBase PrevParticipant { get; set; }

[JsonPropertyName("new_participant")]
		public ChannelParticipantBase NewParticipant { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevParticipant);
			writer.Write(NewParticipant);

		}

		public override void Deserialize(Reader reader)
		{
			PrevParticipant = reader.Read<ChannelParticipantBase>();
			NewParticipant = reader.Read<ChannelParticipantBase>();
		}

		public override string ToString()
		{
			return "channelAdminLogEventActionParticipantToggleBan";
		}
	}
}