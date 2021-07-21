using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class GetMessagePublicForwards : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1445996571; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

[JsonPropertyName("offset_rate")]
		public int OffsetRate { get; set; }

[JsonPropertyName("offset_peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase OffsetPeer { get; set; }

[JsonPropertyName("offset_id")]
		public int OffsetId { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}