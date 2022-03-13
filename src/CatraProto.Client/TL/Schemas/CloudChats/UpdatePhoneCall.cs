using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePhoneCall : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1425052898; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("phone_call")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCall { get; set; }


        #nullable enable
 public UpdatePhoneCall (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase phoneCall)
{
 PhoneCall = phoneCall;
 
}
#nullable disable
        internal UpdatePhoneCall() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PhoneCall);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneCall = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase>();

		}
				
		public override string ToString()
		{
		    return "updatePhoneCall";
		}
	}
}