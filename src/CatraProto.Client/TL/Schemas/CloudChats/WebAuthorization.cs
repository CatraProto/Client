using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebAuthorization : CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase
	{


        public static int StaticConstructorId { get => -892779534; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public override long Hash { get; set; }

[JsonPropertyName("bot_id")]
		public override int BotId { get; set; }

[JsonPropertyName("domain")]
		public override string Domain { get; set; }

[JsonPropertyName("browser")]
		public override string Browser { get; set; }

[JsonPropertyName("platform")]
		public override string Platform { get; set; }

[JsonPropertyName("date_created")]
		public override int DateCreated { get; set; }

[JsonPropertyName("date_active")]
		public override int DateActive { get; set; }

[JsonPropertyName("ip")]
		public override string Ip { get; set; }

[JsonPropertyName("region")]
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
			BotId = reader.Read<int>();
			Domain = reader.Read<string>();
			Browser = reader.Read<string>();
			Platform = reader.Read<string>();
			DateCreated = reader.Read<int>();
			DateActive = reader.Read<int>();
			Ip = reader.Read<string>();
			Region = reader.Read<string>();

		}
	}
}