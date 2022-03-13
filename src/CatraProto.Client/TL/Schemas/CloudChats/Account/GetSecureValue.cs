using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetSecureValue : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1936088002; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("types")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> Types { get; set; }

        
        #nullable enable
 public GetSecureValue (IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase> types)
{
 Types = types;
 
}
#nullable disable
                
        internal GetSecureValue() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Types);

		}

		public void Deserialize(Reader reader)
		{
			Types = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();

		}
		
		public override string ToString()
		{
		    return "account.getSecureValue";
		}
	}
}