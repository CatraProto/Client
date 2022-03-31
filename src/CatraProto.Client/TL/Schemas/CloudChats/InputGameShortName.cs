using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputGameShortName : CatraProto.Client.TL.Schemas.CloudChats.InputGameBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1020139510; }
        
[Newtonsoft.Json.JsonProperty("bot_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase BotId { get; set; }

[Newtonsoft.Json.JsonProperty("short_name")]
		public string ShortName { get; set; }


        #nullable enable
 public InputGameShortName (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase botId,string shortName)
{
 BotId = botId;
ShortName = shortName;
 
}
#nullable disable
        internal InputGameShortName() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(BotId);
			writer.Write(ShortName);

		}

		public override void Deserialize(Reader reader)
		{
			BotId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			ShortName = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "inputGameShortName";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}