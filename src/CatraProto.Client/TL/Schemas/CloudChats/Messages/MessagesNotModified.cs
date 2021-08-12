using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessagesNotModified : MessagesBase
	{


        public static int StaticConstructorId { get => 1951620897; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("count")]
		public int Count { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.messagesNotModified";
		}
	}
}