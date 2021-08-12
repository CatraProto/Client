using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionUpdatePinned : ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => -370660328; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("message")]
		public MessageBase Message { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Message);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<MessageBase>();
		}

		public override string ToString()
		{
			return "channelAdminLogEventActionUpdatePinned";
		}
	}
}