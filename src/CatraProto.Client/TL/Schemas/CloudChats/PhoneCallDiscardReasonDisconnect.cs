using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCallDiscardReasonDisconnect : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase
	{


        public static int StaticConstructorId { get => -527056480; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        

        
        public PhoneCallDiscardReasonDisconnect() 
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
		    return "phoneCallDiscardReasonDisconnect";
		}
	}
}