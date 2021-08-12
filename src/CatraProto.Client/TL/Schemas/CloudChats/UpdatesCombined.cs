using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatesCombined : UpdatesBase
	{


        public static int StaticConstructorId { get => 1918567619; }
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

[JsonPropertyName("seq_start")]
		public int SeqStart { get; set; }

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
			writer.Write(SeqStart);
			writer.Write(Seq);

		}

		public override void Deserialize(Reader reader)
		{
			Updates = reader.ReadVector<UpdateBase>();
			Users = reader.ReadVector<UserBase>();
			Chats = reader.ReadVector<ChatBase>();
			Date = reader.Read<int>();
			SeqStart = reader.Read<int>();
			Seq = reader.Read<int>();
		}

		public override string ToString()
		{
			return "updatesCombined";
		}
	}
}