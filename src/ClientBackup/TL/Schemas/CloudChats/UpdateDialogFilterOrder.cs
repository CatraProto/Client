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
	public partial class UpdateDialogFilterOrder : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1512627963; }
        
[Newtonsoft.Json.JsonProperty("order")]
		public List<int> Order { get; set; }


        #nullable enable
 public UpdateDialogFilterOrder (List<int> order)
{
 Order = order;
 
}
#nullable disable
        internal UpdateDialogFilterOrder() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

			writer.WriteVector(Order, false);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryorder = reader.ReadVector<int>(ParserTypes.Int);
if(tryorder.IsError){
return ReadResult<IObject>.Move(tryorder);
}
Order = tryorder.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updateDialogFilterOrder";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}