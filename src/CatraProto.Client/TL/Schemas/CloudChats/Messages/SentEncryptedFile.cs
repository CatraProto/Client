using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SentEncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase
	{


        public static int StaticConstructorId { get => -1802240206; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("date")]
		public override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("file")]
		public CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase File { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Date);
			writer.Write(File);

		}

		public override void Deserialize(Reader reader)
		{
			Date = reader.Read<int>();
			File = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase>();

		}
				
		public override string ToString()
		{
		    return "messages.sentEncryptedFile";
		}
	}
}