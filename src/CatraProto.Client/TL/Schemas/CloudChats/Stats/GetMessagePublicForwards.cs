using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class GetMessagePublicForwards : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1445996571; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("offset_rate")]
		public int OffsetRate { get; set; }

[Newtonsoft.Json.JsonProperty("offset_peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase OffsetPeer { get; set; }

[Newtonsoft.Json.JsonProperty("offset_id")]
		public int OffsetId { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

        
        #nullable enable
 public GetMessagePublicForwards (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,int msgId,int offsetRate,CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer,int offsetId,int limit)
{
 Channel = channel;
MsgId = msgId;
OffsetRate = offsetRate;
OffsetPeer = offsetPeer;
OffsetId = offsetId;
Limit = limit;
 
}
#nullable disable
                
        internal GetMessagePublicForwards() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(MsgId);
			writer.Write(OffsetRate);
			writer.Write(OffsetPeer);
			writer.Write(OffsetId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			MsgId = reader.Read<int>();
			OffsetRate = reader.Read<int>();
			OffsetPeer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			OffsetId = reader.Read<int>();
			Limit = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "stats.getMessagePublicForwards";
		}
	}
}