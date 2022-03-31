using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class ReqPqMulti : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1099002127; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.ResPQBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("nonce")]
		public System.Numerics.BigInteger Nonce { get; set; }

        
        #nullable enable
 public ReqPqMulti (System.Numerics.BigInteger nonce)
{
 Nonce = nonce;
 
}
#nullable disable
                
        internal ReqPqMulti() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Nonce);

		}

		public void Deserialize(Reader reader)
		{
			Nonce = reader.Read<System.Numerics.BigInteger>(128);

		}

		public override string ToString()
		{
		    return "req_pq_multi";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}