using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputCheckPasswordSRP : CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase
	{


        public static int StaticConstructorId { get => -763367294; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("srp_id")]
		public long SrpId { get; set; }

[Newtonsoft.Json.JsonProperty("A")]
		public byte[] A { get; set; }

[Newtonsoft.Json.JsonProperty("M1")]
		public byte[] M1 { get; set; }


        #nullable enable
 public InputCheckPasswordSRP (long srpId,byte[] a,byte[] m1)
{
 SrpId = srpId;
A = a;
M1 = m1;
 
}
#nullable disable
        internal InputCheckPasswordSRP() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(SrpId);
			writer.Write(A);
			writer.Write(M1);

		}

		public override void Deserialize(Reader reader)
		{
			SrpId = reader.Read<long>();
			A = reader.Read<byte[]>();
			M1 = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "inputCheckPasswordSRP";
		}
	}
}