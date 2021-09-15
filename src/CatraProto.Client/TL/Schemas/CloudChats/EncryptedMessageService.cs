using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedMessageService : CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase
	{


        public static int StaticConstructorId { get => 594758406; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("random_id")]
		public override long RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("chat_id")]
		public override int ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public override byte[] Bytes { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(RandomId);
			writer.Write(ChatId);
			writer.Write(Date);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			RandomId = reader.Read<long>();
			ChatId = reader.Read<int>();
			Date = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "encryptedMessageService";
		}
	}
}