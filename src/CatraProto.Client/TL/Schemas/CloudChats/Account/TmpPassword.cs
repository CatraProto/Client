using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class TmpPassword : CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase
	{


        public static int StaticConstructorId { get => -614138572; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("tmp_password")]
		public override byte[] TmpPasswordField { get; set; }

[Newtonsoft.Json.JsonProperty("valid_until")]
		public override int ValidUntil { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(TmpPasswordField);
			writer.Write(ValidUntil);

		}

		public override void Deserialize(Reader reader)
		{
			TmpPasswordField = reader.Read<byte[]>();
			ValidUntil = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "account.tmpPassword";
		}
	}
}