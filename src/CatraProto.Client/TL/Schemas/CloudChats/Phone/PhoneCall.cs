using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class PhoneCall : CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase
	{


        public static int StaticConstructorId { get => -326966976; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("PhoneCall_")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCall_ { get; set; }

[JsonPropertyName("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhoneCall_);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			PhoneCall_ = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}