using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhotoSize : PhotoSizeBase
	{


        public static int StaticConstructorId { get => 2009052699; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("type")]
		public override string Type { get; set; }

[JsonPropertyName("location")]
		public FileLocationBase Location { get; set; }

[JsonPropertyName("w")]
		public int W { get; set; }

[JsonPropertyName("h")]
		public int H { get; set; }

[JsonPropertyName("size")]
		public int Size { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Location);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Size);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<string>();
			Location = reader.Read<FileLocationBase>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Size = reader.Read<int>();

		}
	}
}