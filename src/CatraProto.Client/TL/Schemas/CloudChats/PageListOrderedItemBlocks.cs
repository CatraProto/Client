using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListOrderedItemBlocks : PageListOrderedItemBase
	{


        public static int StaticConstructorId { get => -1730311882; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("num")]
		public override string Num { get; set; }

[JsonPropertyName("blocks")]
		public IList<PageBlockBase> Blocks { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Num);
			writer.Write(Blocks);

		}

		public override void Deserialize(Reader reader)
		{
			Num = reader.Read<string>();
			Blocks = reader.ReadVector<PageBlockBase>();
		}

		public override string ToString()
		{
			return "pageListOrderedItemBlocks";
		}
	}
}