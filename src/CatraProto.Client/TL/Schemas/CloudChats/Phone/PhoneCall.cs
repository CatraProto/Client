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
		public override CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCallField { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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