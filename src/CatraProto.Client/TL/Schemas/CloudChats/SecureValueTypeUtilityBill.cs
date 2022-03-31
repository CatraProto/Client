using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueTypeUtilityBill : CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -63531698; }
        

        
        public SecureValueTypeUtilityBill() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
		
		public override string ToString()
		{
		    return "secureValueTypeUtilityBill";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}