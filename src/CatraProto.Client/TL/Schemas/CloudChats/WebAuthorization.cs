using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebAuthorization : CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase
	{


        public static int StaticConstructorId { get => -1493633966; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("hash")]
		public sealed override long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("bot_id")]
		public sealed override long BotId { get; set; }

[Newtonsoft.Json.JsonProperty("domain")]
		public sealed override string Domain { get; set; }

[Newtonsoft.Json.JsonProperty("browser")]
		public sealed override string Browser { get; set; }

[Newtonsoft.Json.JsonProperty("platform")]
		public sealed override string Platform { get; set; }

[Newtonsoft.Json.JsonProperty("date_created")]
		public sealed override int DateCreated { get; set; }

[Newtonsoft.Json.JsonProperty("date_active")]
		public sealed override int DateActive { get; set; }

[Newtonsoft.Json.JsonProperty("ip")]
		public sealed override string Ip { get; set; }

[Newtonsoft.Json.JsonProperty("region")]
		public sealed override string Region { get; set; }


        #nullable enable
 public WebAuthorization (long hash,long botId,string domain,string browser,string platform,int dateCreated,int dateActive,string ip,string region)
{
 Hash = hash;
BotId = botId;
Domain = domain;
Browser = browser;
Platform = platform;
DateCreated = dateCreated;
DateActive = dateActive;
Ip = ip;
Region = region;
 
}
#nullable disable
        internal WebAuthorization() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(BotId);
			writer.Write(Domain);
			writer.Write(Browser);
			writer.Write(Platform);
			writer.Write(DateCreated);
			writer.Write(DateActive);
			writer.Write(Ip);
			writer.Write(Region);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<long>();
			BotId = reader.Read<long>();
			Domain = reader.Read<string>();
			Browser = reader.Read<string>();
			Platform = reader.Read<string>();
			DateCreated = reader.Read<int>();
			DateActive = reader.Read<int>();
			Ip = reader.Read<string>();
			Region = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "webAuthorization";
		}
	}
}