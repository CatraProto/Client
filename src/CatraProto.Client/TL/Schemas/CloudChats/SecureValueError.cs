using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueError : SecureValueErrorBase
	{


        public static int StaticConstructorId { get => -2036501105; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("type")]
		public override SecureValueTypeBase Type { get; set; }

[JsonPropertyName("hash")]
		public byte[] Hash { get; set; }

[JsonPropertyName("text")]
		public override string Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Hash);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<SecureValueTypeBase>();
			Hash = reader.Read<byte[]>();
			Text = reader.Read<string>();
		}

		public override string ToString()
		{
			return "secureValueError";
		}
	}
}