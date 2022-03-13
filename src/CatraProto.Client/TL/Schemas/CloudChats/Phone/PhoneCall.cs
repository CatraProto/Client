using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class PhoneCall : CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase
	{


        public static int StaticConstructorId { get => -326966976; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("phone_call")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCallField { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public PhoneCall (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase phoneCallField,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 PhoneCallField = phoneCallField;
Users = users;
 
}
#nullable disable
        internal PhoneCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PhoneCallField);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneCallField = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "phone.phoneCall";
		}
	}
}