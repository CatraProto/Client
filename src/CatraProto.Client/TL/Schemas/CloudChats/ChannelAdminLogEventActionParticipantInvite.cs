using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionParticipantInvite : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => -484690728; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("participant")]
		public ChannelParticipantBase Participant { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Participant);

		}

		public override void Deserialize(Reader reader)
		{
			Participant = reader.Read<ChannelParticipantBase>();

		}
	}
}