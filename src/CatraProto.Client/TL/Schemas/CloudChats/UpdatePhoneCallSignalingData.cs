using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePhoneCallSignalingData : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 643940105; }
        
[Newtonsoft.Json.JsonProperty("phone_call_id")]
		public long PhoneCallId { get; set; }

[Newtonsoft.Json.JsonProperty("data")]
		public byte[] Data { get; set; }


        #nullable enable
 public UpdatePhoneCallSignalingData (long phoneCallId,byte[] data)
{
 PhoneCallId = phoneCallId;
Data = data;
 
}
#nullable disable
        internal UpdatePhoneCallSignalingData() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(PhoneCallId);
			writer.Write(Data);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneCallId = reader.Read<long>();
			Data = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "updatePhoneCallSignalingData";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}