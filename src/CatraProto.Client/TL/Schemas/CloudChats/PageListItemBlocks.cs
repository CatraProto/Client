using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListItemBlocks : CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 635466748; }
        
[Newtonsoft.Json.JsonProperty("blocks")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }


        #nullable enable
 public PageListItemBlocks (IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> blocks)
{
 Blocks = blocks;
 
}
#nullable disable
        internal PageListItemBlocks() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Blocks);

		}

		public override void Deserialize(Reader reader)
		{
			Blocks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();

		}
		
		public override string ToString()
		{
		    return "pageListItemBlocks";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}