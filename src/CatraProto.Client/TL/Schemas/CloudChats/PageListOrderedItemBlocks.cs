using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListOrderedItemBlocks : CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase
	{


        public static int StaticConstructorId { get => -1730311882; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("num")]
		public override string Num { get; set; }

[Newtonsoft.Json.JsonProperty("blocks")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }

        
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
			Blocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();

		}
				
		public override string ToString()
		{
		    return "pageListOrderedItemBlocks";
		}
	}
}