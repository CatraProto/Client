using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockOrderedList : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        public static int StaticConstructorId { get => -1702174239; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("items")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase> Items { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Items);

		}

		public override void Deserialize(Reader reader)
		{
			Items = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase>();

		}
				
		public override string ToString()
		{
		    return "pageBlockOrderedList";
		}
	}
}