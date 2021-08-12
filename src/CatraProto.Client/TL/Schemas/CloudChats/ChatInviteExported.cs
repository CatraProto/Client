using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInviteExported : ExportedChatInviteBase
	{


        public static int StaticConstructorId { get => -64092740; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("link")]
		public string Link { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Link);

		}

		public override void Deserialize(Reader reader)
		{
			Link = reader.Read<string>();
		}

		public override string ToString()
		{
			return "chatInviteExported";
		}
	}
}