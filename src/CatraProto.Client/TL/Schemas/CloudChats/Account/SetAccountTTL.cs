using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetAccountTTL : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 608323678; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("ttl")]
		public CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase Ttl { get; set; }

        
        #nullable enable
 public SetAccountTTL (CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase ttl)
{
 Ttl = ttl;
 
}
#nullable disable
                
        internal SetAccountTTL() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Ttl);

		}

		public void Deserialize(Reader reader)
		{
			Ttl = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase>();

		}
		
		public override string ToString()
		{
		    return "account.setAccountTTL";
		}
	}
}