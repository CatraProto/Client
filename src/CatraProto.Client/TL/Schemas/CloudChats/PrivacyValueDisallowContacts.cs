using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyValueDisallowContacts : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -125240806; }
        

        
        public PrivacyValueDisallowContacts() 
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
		    return "privacyValueDisallowContacts";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}