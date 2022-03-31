using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyKeyAddedByPhone : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1124062251; }
        

        
        public PrivacyKeyAddedByPhone() 
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
		    return "privacyKeyAddedByPhone";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}