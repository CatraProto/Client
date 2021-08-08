using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DhConfig : DhConfigBase
	{


        public static int StaticConstructorId { get => 740433629; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("g")]
		public int G { get; set; }

[JsonPropertyName("p")]
		public byte[] P { get; set; }

[JsonPropertyName("version")]
		public int Version { get; set; }

[JsonPropertyName("random")]
		public override byte[] Random { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(G);
			writer.Write(P);
			writer.Write(Version);
			writer.Write(Random);

		}

		public override void Deserialize(Reader reader)
		{
			G = reader.Read<int>();
			P = reader.Read<byte[]>();
			Version = reader.Read<int>();
			Random = reader.Read<byte[]>();

		}
	}
}