using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SaveSecureValue : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1986010339; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("value")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase Value { get; set; }

[Newtonsoft.Json.JsonProperty("secure_secret_id")]
		public long SecureSecretId { get; set; }

        
        #nullable enable
 public SaveSecureValue (CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase value,long secureSecretId)
{
 Value = value;
SecureSecretId = secureSecretId;
 
}
#nullable disable
                
        internal SaveSecureValue() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Value);
			writer.Write(SecureSecretId);

		}

		public void Deserialize(Reader reader)
		{
			Value = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputSecureValueBase>();
			SecureSecretId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "account.saveSecureValue";
		}
	}
}