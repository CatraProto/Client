using System;
using System.Text.Json.Serialization;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class GetMessagePublicForwards : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1445996571; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(MessagesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("channel")]
		public InputChannelBase Channel { get; set; }

[JsonPropertyName("msg_id")]
		public int MsgId { get; set; }

[JsonPropertyName("offset_rate")]
		public int OffsetRate { get; set; }

[JsonPropertyName("offset_peer")]
		public InputPeerBase OffsetPeer { get; set; }

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
			Channel = reader.Read<InputChannelBase>();
			MsgId = reader.Read<int>();
			OffsetRate = reader.Read<int>();
			OffsetPeer = reader.Read<InputPeerBase>();
			OffsetId = reader.Read<int>();
			Limit = reader.Read<int>();
		}

		public override string ToString()
		{
			return "stats.getMessagePublicForwards";
		}
	}
}