using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class WallPapers : WallPapersBase
	{


        public static int StaticConstructorId { get => 1881892265; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("wallpapers")]
		public IList<WallPaperBase> Wallpapers { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Wallpapers);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Wallpapers = reader.ReadVector<WallPaperBase>();

		}
	}
}