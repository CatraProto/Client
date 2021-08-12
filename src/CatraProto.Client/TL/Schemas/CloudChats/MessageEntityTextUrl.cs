using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageEntityTextUrl : MessageEntityBase
	{


        public static int StaticConstructorId { get => 1990644519; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("offset")]
		public override int Offset { get; set; }

[JsonPropertyName("length")]
		public override int Length { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Offset);
			writer.Write(Length);
			writer.Write(Url);

		}

		public override void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Length = reader.Read<int>();
			Url = reader.Read<string>();
		}

		public override string ToString()
		{
			return "messageEntityTextUrl";
		}
	}
}