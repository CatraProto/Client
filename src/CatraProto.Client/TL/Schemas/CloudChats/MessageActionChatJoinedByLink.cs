using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatJoinedByLink : MessageActionBase
	{


        public static int StaticConstructorId { get => -123931160; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("inviter_id")]
		public int InviterId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(InviterId);

		}

		public override void Deserialize(Reader reader)
		{
			InviterId = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messageActionChatJoinedByLink";
		}
	}
}