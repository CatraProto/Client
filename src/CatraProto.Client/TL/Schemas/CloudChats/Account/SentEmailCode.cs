using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SentEmailCode : CatraProto.Client.TL.Schemas.CloudChats.Account.SentEmailCodeBase
	{


        public static int StaticConstructorId { get => -2128640689; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("email_pattern")]
		public override string EmailPattern { get; set; }

[JsonPropertyName("length")]
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
	}
}