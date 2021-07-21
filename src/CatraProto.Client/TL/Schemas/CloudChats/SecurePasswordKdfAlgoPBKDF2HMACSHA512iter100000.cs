using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase
	{


        public static int StaticConstructorId { get => -1141711456; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("salt")]
		public byte[] Salt { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Salt);

		}

		public override void Deserialize(Reader reader)
		{
			Salt = reader.Read<byte[]>();

		}
	}
}