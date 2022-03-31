using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PrivacyValueAllowUsers : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1198497870; }
        
[Newtonsoft.Json.JsonProperty("users")]
		public IList<long> Users { get; set; }


        #nullable enable
 public PrivacyValueAllowUsers (IList<long> users)
{
 Users = users;
 
}
#nullable disable
        internal PrivacyValueAllowUsers() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<long>();

		}
		
		public override string ToString()
		{
		    return "privacyValueAllowUsers";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}