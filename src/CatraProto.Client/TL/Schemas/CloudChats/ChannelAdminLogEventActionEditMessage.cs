using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionEditMessage : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 1889215493; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_message")]
		public MessageBase PrevMessage { get; set; }

[JsonPropertyName("new_message")]
		public MessageBase NewMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevMessage);
			writer.Write(NewMessage);

		}

		public override void Deserialize(Reader reader)
		{
			PrevMessage = reader.Read<MessageBase>();
			NewMessage = reader.Read<MessageBase>();

		}
	}
}