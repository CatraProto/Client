using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineMessageID : InputBotInlineMessageIDBase
	{


        public static int StaticConstructorId { get => -1995686519; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("dc_id")]
		public override int DcId { get; set; }

[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("access_hash")]
		public override long AccessHash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(DcId);
			writer.Write(Id);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			DcId = reader.Read<int>();
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
		}

		public override string ToString()
		{
			return "inputBotInlineMessageID";
		}
	}
}