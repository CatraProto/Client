using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UUpdates : UpdatesBase
	{


        public static int StaticConstructorId { get => 1957577280; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("updates")]
		public IList<UpdateBase> Updates { get; set; }

[JsonPropertyName("users")]
		public IList<UserBase> Users { get; set; }

[JsonPropertyName("chats")]
		public IList<ChatBase> Chats { get; set; }

[JsonPropertyName("date")]
		public int Date { get; set; }

[JsonPropertyName("seq")]
		public int Seq { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Updates);
			writer.Write(Users);
			writer.Write(Chats);
			writer.Write(Date);
			writer.Write(Seq);

		}

		public override void Deserialize(Reader reader)
		{
			Updates = reader.ReadVector<UpdateBase>();
			Users = reader.ReadVector<UserBase>();
			Chats = reader.ReadVector<ChatBase>();
			Date = reader.Read<int>();
			Seq = reader.Read<int>();

		}
	}
}