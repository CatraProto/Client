using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatDeleteUser : MessageActionBase
	{


        public static int StaticConstructorId { get => -1297179892; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public int UserId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messageActionChatDeleteUser";
		}
	}
}