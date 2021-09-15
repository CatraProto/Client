using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPeerChannelFromMessage : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
	{


        public static int StaticConstructorId { get => -1667893317; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public int ChannelId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(ChannelId);

		}

		public override void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			MsgId = reader.Read<int>();
			ChannelId = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "inputPeerChannelFromMessage";
		}
	}
}