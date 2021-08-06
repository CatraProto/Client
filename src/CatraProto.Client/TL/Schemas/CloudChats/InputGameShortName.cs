using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputGameShortName : CatraProto.Client.TL.Schemas.CloudChats.InputGameBase
	{


        public static int StaticConstructorId { get => -1020139510; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("bot_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase BotId { get; set; }

[JsonPropertyName("short_name")]
		public string ShortName { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(ShortName);

		}

		public override void Deserialize(Reader reader)
		{
			BotId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			ShortName = reader.Read<string>();

		}
	}
}