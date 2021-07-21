using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UserStatusOnline : CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase
	{


        public static int StaticConstructorId { get => -306628279; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("expires")]
		public int Expires { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Expires);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();

		}
	}
}