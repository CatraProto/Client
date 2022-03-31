using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SentEncryptedMessage : CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1443858741; }
        
[Newtonsoft.Json.JsonProperty("date")]
		public sealed override int Date { get; set; }


        #nullable enable
 public SentEncryptedMessage (int date)
{
 Date = date;
 
}
#nullable disable
        internal SentEncryptedMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			Date = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.sentEncryptedMessage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}