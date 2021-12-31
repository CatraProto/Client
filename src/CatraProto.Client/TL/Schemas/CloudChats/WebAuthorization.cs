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
		public override long Hash { get; set; }

[Newtonsoft.Json.JsonProperty("bot_id")]
		public override long BotId { get; set; }

[Newtonsoft.Json.JsonProperty("domain")]
		public override string Domain { get; set; }

[Newtonsoft.Json.JsonProperty("browser")]
		public override string Browser { get; set; }

[Newtonsoft.Json.JsonProperty("platform")]
		public override string Platform { get; set; }

[Newtonsoft.Json.JsonProperty("date_created")]
		public override int DateCreated { get; set; }

[Newtonsoft.Json.JsonProperty("date_active")]
		public override int DateActive { get; set; }

[Newtonsoft.Json.JsonProperty("ip")]
		public override string Ip { get; set; }

[Newtonsoft.Json.JsonProperty("region")]
		public override string Region { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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