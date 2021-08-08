using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEvent : ChannelAdminLogEventBase
	{


        public static int StaticConstructorId { get => 995769920; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override long Id { get; set; }

[JsonPropertyName("date")]
		public override int Date { get; set; }

[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("action")]
		public override ChannelAdminLogEventActionBase Action { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Date);
			writer.Write(UserId);
			writer.Write(Action);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Date = reader.Read<int>();
			UserId = reader.Read<int>();
			Action = reader.Read<ChannelAdminLogEventActionBase>();

		}
	}
}