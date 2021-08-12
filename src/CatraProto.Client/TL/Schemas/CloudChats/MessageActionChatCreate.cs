using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionChatCreate : MessageActionBase
	{


        public static int StaticConstructorId { get => -1503425638; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("users")]
		public IList<int> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Title);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Title = reader.Read<string>();
			Users = reader.ReadVector<int>();
		}

		public override string ToString()
		{
			return "messageActionChatCreate";
		}
	}
}