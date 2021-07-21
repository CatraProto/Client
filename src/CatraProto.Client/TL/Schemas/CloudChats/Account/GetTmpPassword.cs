using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetTmpPassword : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1151208273; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("password")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }

[JsonPropertyName("period")]
		public int Period { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Password);
			writer.Write(Period);

		}

		public void Deserialize(Reader reader)
		{
			Password = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
			Period = reader.Read<int>();

		}
	}
}