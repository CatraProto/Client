using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Search : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			FromId = 1 << 0,
			TopMsgId = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 204812012; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(MessagesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

		[JsonPropertyName("peer")] public InputPeerBase Peer { get; set; }

[JsonPropertyName("q")]
		public string Q { get; set; }

		[JsonPropertyName("from_id")] public InputPeerBase FromId { get; set; }

[JsonPropertyName("top_msg_id")]
		public int? TopMsgId { get; set; }

		[JsonPropertyName("filter")] public MessagesFilterBase Filter { get; set; }

[JsonPropertyName("min_date")]
		public int MinDate { get; set; }

[JsonPropertyName("max_date")]
		public int MaxDate { get; set; }

[JsonPropertyName("offset_id")]
		public int OffsetId { get; set; }

[JsonPropertyName("add_offset")]
		public int AddOffset { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }

[JsonPropertyName("max_id")]
		public int MaxId { get; set; }

[JsonPropertyName("min_id")]
		public int MinId { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{
			Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Q);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FromId);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(TopMsgId.Value);
			}

			writer.Write(Filter);
			writer.Write(MinDate);
			writer.Write(MaxDate);
			writer.Write(OffsetId);
			writer.Write(AddOffset);
			writer.Write(Limit);
			writer.Write(MaxId);
			writer.Write(MinId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Peer = reader.Read<InputPeerBase>();
			Q = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FromId = reader.Read<InputPeerBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				TopMsgId = reader.Read<int>();
			}

			Filter = reader.Read<MessagesFilterBase>();
			MinDate = reader.Read<int>();
			MaxDate = reader.Read<int>();
			OffsetId = reader.Read<int>();
			AddOffset = reader.Read<int>();
			Limit = reader.Read<int>();
			MaxId = reader.Read<int>();
			MinId = reader.Read<int>();
			Hash = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.search";
		}
	}
}