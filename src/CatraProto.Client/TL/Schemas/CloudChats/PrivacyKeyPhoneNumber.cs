using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyKeyPhoneNumber : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -778378131; }
        

        
        public PrivacyKeyPhoneNumber() 
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
		    return "privacyKeyPhoneNumber";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}