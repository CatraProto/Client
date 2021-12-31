using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotCommands : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 1299263278; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("bot_id")]
		public long BotId { get; set; }

[Newtonsoft.Json.JsonProperty("commands")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(BotId);
			writer.Write(Commands);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			BotId = reader.Read<long>();
			Commands = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase>();

		}
				
		public override string ToString()
		{
		    return "updateBotCommands";
		}
	}
}