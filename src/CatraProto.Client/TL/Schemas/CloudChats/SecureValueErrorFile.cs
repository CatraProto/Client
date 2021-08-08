using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueErrorFile : SecureValueErrorBase
	{


        public static int StaticConstructorId { get => 2054162547; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("type")]
		public override SecureValueTypeBase Type { get; set; }

[JsonPropertyName("file_hash")]
		public byte[] FileHash { get; set; }

[JsonPropertyName("text")]
		public override string Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(FileHash);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<SecureValueTypeBase>();
			FileHash = reader.Read<byte[]>();
			Text = reader.Read<string>();

		}
	}
}