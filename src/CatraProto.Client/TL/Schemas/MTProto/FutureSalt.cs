using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class FutureSalt : CatraProto.Client.TL.Schemas.MTProto.FutureSaltBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 155834844; }
        
[Newtonsoft.Json.JsonProperty("valid_since")]
		public sealed override int ValidSince { get; set; }

[Newtonsoft.Json.JsonProperty("valid_until")]
		public sealed override int ValidUntil { get; set; }

[Newtonsoft.Json.JsonProperty("salt")]
		public sealed override long Salt { get; set; }


        #nullable enable
 public FutureSalt (int validSince,int validUntil,long salt)
{
 ValidSince = validSince;
ValidUntil = validUntil;
Salt = salt;
 
}
#nullable disable
        internal FutureSalt() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ValidSince);
			writer.Write(ValidUntil);
			writer.Write(Salt);

		}

		public override void Deserialize(Reader reader)
		{
			ValidSince = reader.Read<int>();
			ValidUntil = reader.Read<int>();
			Salt = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "future_salt";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}