using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListItemBlocks : PageListItemBase
	{


        public static int StaticConstructorId { get => 635466748; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("blocks")]
		public IList<PageBlockBase> Blocks { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Blocks);

		}

		public override void Deserialize(Reader reader)
		{
			Blocks = reader.ReadVector<PageBlockBase>();
		}

		public override string ToString()
		{
			return "pageListItemBlocks";
		}
	}
}