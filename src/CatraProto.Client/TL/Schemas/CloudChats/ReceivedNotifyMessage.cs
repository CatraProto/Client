using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ReceivedNotifyMessage : ReceivedNotifyMessageBase
	{


        public static int StaticConstructorId { get => -1551583367; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override int Id { get; set; }

[JsonPropertyName("flags")]
		public override int Flags { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Flags);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			Flags = reader.Read<int>();
		}

		public override string ToString()
		{
			return "receivedNotifyMessage";
		}
	}
}