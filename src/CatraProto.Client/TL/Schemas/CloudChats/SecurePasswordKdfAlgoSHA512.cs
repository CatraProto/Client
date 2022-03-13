using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecurePasswordKdfAlgoSHA512 : CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase
	{


        public static int StaticConstructorId { get => -2042159726; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("salt")]
		public byte[] Salt { get; set; }


        #nullable enable
 public SecurePasswordKdfAlgoSHA512 (byte[] salt)
{
 Salt = salt;
 
}
#nullable disable
        internal SecurePasswordKdfAlgoSHA512() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Salt);

		}

		public override void Deserialize(Reader reader)
		{
			Salt = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "securePasswordKdfAlgoSHA512";
		}
	}
}