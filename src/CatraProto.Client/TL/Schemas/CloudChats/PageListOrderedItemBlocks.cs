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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1730311882; }
        
[Newtonsoft.Json.JsonProperty("num")]
		public sealed override string Num { get; set; }

[Newtonsoft.Json.JsonProperty("blocks")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }


        #nullable enable
 public PageListOrderedItemBlocks (string num,IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks)
{
 Num = num;
Blocks = blocks;
 
}
#nullable disable
        internal PageListOrderedItemBlocks() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}