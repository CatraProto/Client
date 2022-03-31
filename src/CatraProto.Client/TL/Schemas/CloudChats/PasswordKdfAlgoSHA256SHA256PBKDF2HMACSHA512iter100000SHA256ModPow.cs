using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow : CatraProto.Client.TL.Schemas.CloudChats.PasswordKdfAlgoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 982592842; }
        
[Newtonsoft.Json.JsonProperty("salt1")]
		public byte[] Salt1 { get; set; }

[Newtonsoft.Json.JsonProperty("salt2")]
		public byte[] Salt2 { get; set; }

[Newtonsoft.Json.JsonProperty("g")]
		public int G { get; set; }

[Newtonsoft.Json.JsonProperty("p")]
		public byte[] P { get; set; }


        #nullable enable
 public PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow (byte[] salt1,byte[] salt2,int g,byte[] p)
{
 Salt1 = salt1;
Salt2 = salt2;
G = g;
P = p;
 
}
#nullable disable
        internal PasswordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Salt1);
			writer.Write(Salt2);
			writer.Write(G);
			writer.Write(P);

		}

		public override void Deserialize(Reader reader)
		{
			Salt1 = reader.Read<byte[]>();
			Salt2 = reader.Read<byte[]>();
			G = reader.Read<int>();
			P = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "passwordKdfAlgoSHA256SHA256PBKDF2HMACSHA512iter100000SHA256ModPow";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}