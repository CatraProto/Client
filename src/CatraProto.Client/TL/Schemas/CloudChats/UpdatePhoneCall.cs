using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePhoneCall : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -1425052898; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("phone_call")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCall { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneCall);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneCall = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase>();

		}
	}
}