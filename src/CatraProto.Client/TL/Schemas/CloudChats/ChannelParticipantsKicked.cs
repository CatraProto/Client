using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantsKicked : ChannelParticipantsFilterBase
	{


        public static int StaticConstructorId { get => -1548400251; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("q")]
		public string Q { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Q);

		}

		public override void Deserialize(Reader reader)
		{
			Q = reader.Read<string>();

		}
	}
}