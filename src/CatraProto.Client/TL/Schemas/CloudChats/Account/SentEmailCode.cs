using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SentEmailCode : CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase
	{


        public static int StaticConstructorId { get => -2128640689; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("email_pattern")]
		public override string EmailPattern { get; set; }

[Newtonsoft.Json.JsonProperty("length")]
		public override int Length { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(EmailPattern);
			writer.Write(Length);

		}

		public override void Deserialize(Reader reader)
		{
			EmailPattern = reader.Read<string>();
			Length = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "account.sentEmailCode";
		}
	}
}