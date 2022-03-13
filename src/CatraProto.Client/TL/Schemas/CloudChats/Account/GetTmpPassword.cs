using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetTmpPassword : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1151208273; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("password")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }

[Newtonsoft.Json.JsonProperty("period")]
		public int Period { get; set; }

        
        #nullable enable
 public GetTmpPassword (CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password,int period)
{
 Password = password;
Period = period;
 
}
#nullable disable
                
        internal GetTmpPassword() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Password);
			writer.Write(Period);

		}

		public void Deserialize(Reader reader)
		{
			Password = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
			Period = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "account.getTmpPassword";
		}
	}
}