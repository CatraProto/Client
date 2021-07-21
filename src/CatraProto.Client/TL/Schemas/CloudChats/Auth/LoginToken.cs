using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class LoginToken : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase
	{


        public static int StaticConstructorId { get => 1654593920; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("expires")]
		public int Expires { get; set; }

[JsonPropertyName("token")]
		public byte[] Token { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Expires);
			writer.Write(Token);

		}

		public override void Deserialize(Reader reader)
		{
			Expires = reader.Read<int>();
			Token = reader.Read<byte[]>();

		}
	}
}