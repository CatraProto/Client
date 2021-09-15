using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedMessage : CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase
	{


        public static int StaticConstructorId { get => -317144808; }
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

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase File { get; set; }

        
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
			writer.Write(File);

		}

		public override void Deserialize(Reader reader)
		{
			RandomId = reader.Read<long>();
			ChatId = reader.Read<int>();
			Date = reader.Read<int>();
			Bytes = reader.Read<byte[]>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>();

		}
				
		public override string ToString()
		{
		    return "encryptedMessage";
		}
	}
}