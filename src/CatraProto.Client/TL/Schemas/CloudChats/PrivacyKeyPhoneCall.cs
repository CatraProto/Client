using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyKeyPhoneCall : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
	{


        public static int StaticConstructorId { get => 1030105979; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public override void Deserialize(Reader reader)
		{

		}
				
		public override string ToString()
		{
		    return "privacyKeyPhoneCall";
		}
	}
}