using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaPoll : MessageMediaBase
	{


        public static int StaticConstructorId { get => 1272375192; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("poll")]
		public PollBase Poll { get; set; }

[JsonPropertyName("results")]
		public PollResultsBase Results { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Poll);
			writer.Write(Results);

		}

		public override void Deserialize(Reader reader)
		{
			Poll = reader.Read<PollBase>();
			Results = reader.Read<PollResultsBase>();
		}

		public override string ToString()
		{
			return "messageMediaPoll";
		}
	}
}