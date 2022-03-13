using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsSaved : CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase
	{


        public static int StaticConstructorId { get => -1056001329; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public string Id { get; set; }

[Newtonsoft.Json.JsonProperty("tmp_password")]
		public byte[] TmpPassword { get; set; }


        #nullable enable
 public InputPaymentCredentialsSaved (string id,byte[] tmpPassword)
{
 Id = id;
TmpPassword = tmpPassword;
 
}
#nullable disable
        internal InputPaymentCredentialsSaved() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(TmpPassword);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			TmpPassword = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "inputPaymentCredentialsSaved";
		}
	}
}