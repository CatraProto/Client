using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RecentMeUrlChat : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1294306862; }
        
[Newtonsoft.Json.JsonProperty("url")]
		public sealed override string Url { get; set; }

[Newtonsoft.Json.JsonProperty("chat_id")]
		public long ChatId { get; set; }


        #nullable enable
 public RecentMeUrlChat (string url,long chatId)
{
 Url = url;
ChatId = chatId;
 
}
#nullable disable
        internal RecentMeUrlChat() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Url);
			writer.Write(ChatId);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			ChatId = reader.Read<long>();

		}
		
		public override string ToString()
		{
		    return "recentMeUrlChat";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}