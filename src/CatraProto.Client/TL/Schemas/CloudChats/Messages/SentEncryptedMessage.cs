using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SentEncryptedMessage : CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase
	{


        public static int StaticConstructorId { get => 1443858741; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("date")]
		public override int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Date = reader.Read<int>();

		}
	}
}