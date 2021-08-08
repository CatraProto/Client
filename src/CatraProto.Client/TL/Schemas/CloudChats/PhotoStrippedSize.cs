using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoStrippedSize : PhotoSizeBase
	{


        public static int StaticConstructorId { get => -525288402; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("type")]
		public override string Type { get; set; }

[JsonPropertyName("bytes")]
		public byte[] Bytes { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			Bytes = reader.Read<byte[]>();

		}
	}
}