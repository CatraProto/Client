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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -317144808; }
        
[Newtonsoft.Json.JsonProperty("random_id")]
		public sealed override long RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("chat_id")]
		public sealed override int ChatId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
		public sealed override byte[] Bytes { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase File { get; set; }


        #nullable enable
 public EncryptedMessage (long randomId,int chatId,int date,byte[] bytes,CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase file)
{
 RandomId = randomId;
ChatId = chatId;
Date = date;
Bytes = bytes;
File = file;
 
}
#nullable disable
        internal EncryptedMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}