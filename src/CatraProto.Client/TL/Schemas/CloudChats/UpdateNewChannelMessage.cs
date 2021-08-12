using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNewChannelMessage : UpdateBase
	{


        public static int StaticConstructorId { get => 1656358105; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("message")]
		public MessageBase Message { get; set; }

[JsonPropertyName("pts")]
		public int Pts { get; set; }

[JsonPropertyName("pts_count")]
		public int PtsCount { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Message);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<MessageBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
		}

		public override string ToString()
		{
			return "updateNewChannelMessage";
		}
	}
}