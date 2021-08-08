using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedMessage : EncryptedMessageBase
	{


        public static int StaticConstructorId { get => -317144808; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("random_id")]
		public override long RandomId { get; set; }

[JsonPropertyName("chat_id")]
		public override int ChatId { get; set; }

[JsonPropertyName("date")]
		public override int Date { get; set; }

[JsonPropertyName("bytes")]
		public override byte[] Bytes { get; set; }

[JsonPropertyName("file")]
		public EncryptedFileBase File { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(RandomId);
			writer.Write(ChatId);
			writer.Write(Date);
			writer.Write(Bytes);
			writer.Write(File);

		}

		public override void Deserialize(Reader reader)
		{
			RandomId = reader.Read<long>();
			ChatId = reader.Read<int>();
			Date = reader.Read<int>();
			Bytes = reader.Read<byte[]>();
			File = reader.Read<EncryptedFileBase>();

		}
	}
}