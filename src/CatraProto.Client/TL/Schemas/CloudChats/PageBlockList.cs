using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockList : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -454524911; }
        
[Newtonsoft.Json.JsonProperty("items")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase> Items { get; set; }


        #nullable enable
 public PageBlockList (IList<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase> items)
{
 Items = items;
 
}
#nullable disable
        internal PageBlockList() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Items);

		}

		public override void Deserialize(Reader reader)
		{
			Items = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase>();

		}
		
		public override string ToString()
		{
		    return "pageBlockList";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}