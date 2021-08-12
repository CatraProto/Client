using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class MsgCopy : MessageCopyBase
	{


        public static int StaticConstructorId { get => -530561358; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("orig_message")]
		public override MessageBase OrigMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(OrigMessage);

		}

		public override void Deserialize(Reader reader)
		{
			OrigMessage = reader.Read<MessageBase>();
		}

		public override string ToString()
		{
			return "msg_copy";
		}
	}
}