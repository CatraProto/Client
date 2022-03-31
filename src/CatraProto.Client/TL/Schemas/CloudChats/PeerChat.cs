using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PeerChat : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 918946202; }
        
[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }


        #nullable enable
 public PeerChat (long chatId)
{
 ChatId = chatId;
 
}
#nullable disable
        internal PeerChat() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChatId);

		}

		public override void Deserialize(Reader reader)
		{
			ChatId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "peerChat";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}