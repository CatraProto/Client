using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDialogFilterOrder : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1512627963; }
        
[Newtonsoft.Json.JsonProperty("order")]
		public IList<int> Order { get; set; }


        #nullable enable
 public UpdateDialogFilterOrder (IList<int> order)
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

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Order);

		}

		public override void Deserialize(Reader reader)
		{
			Order = reader.ReadVector<int>();

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