using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockOrderedList : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1702174239; }
        
[Newtonsoft.Json.JsonProperty("items")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase> Items { get; set; }


        #nullable enable
 public PageBlockOrderedList (List<CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase> items)
{
 Items = items;
 
}
#nullable disable
        internal PageBlockOrderedList() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkitems = 			writer.WriteVector(Items, false);
if(checkitems.IsError){
 return checkitems; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryitems = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageListOrderedItemBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryitems.IsError){
return ReadResult<IObject>.Move(tryitems);
}
Items = tryitems.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "pageBlockOrderedList";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}