using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StartBot : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -421563528; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("bot")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public long RandomId { get; set; }

[Newtonsoft.Json.JsonProperty("start_param")]
		public string StartParam { get; set; }

        
        #nullable enable
 public StartBot (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot,CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,long randomId,string startParam)
{
 Bot = bot;
Peer = peer;
RandomId = randomId;
StartParam = startParam;
 
}
#nullable disable
                
        internal StartBot() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Bot);
			writer.Write(Peer);
			writer.Write(RandomId);
			writer.Write(StartParam);

		}

		public void Deserialize(Reader reader)
		{
			Bot = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			RandomId = reader.Read<long>();
			StartParam = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "messages.startBot";
		}
	}
}