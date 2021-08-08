using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SearchGlobal : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			FolderId = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1271290010; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(MessagesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("folder_id")]
		public int? FolderId { get; set; }

[JsonPropertyName("q")]
		public string Q { get; set; }

[JsonPropertyName("filter")]
		public MessagesFilterBase Filter { get; set; }

[JsonPropertyName("min_date")]
		public int MinDate { get; set; }

[JsonPropertyName("max_date")]
		public int MaxDate { get; set; }

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
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FolderId.Value);
			}

			writer.Write(Q);
			writer.Write(Filter);
			writer.Write(MinDate);
			writer.Write(MaxDate);
			writer.Write(OffsetRate);
			writer.Write(OffsetPeer);
			writer.Write(OffsetId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				FolderId = reader.Read<int>();
			}

			Q = reader.Read<string>();
			Filter = reader.Read<MessagesFilterBase>();
			MinDate = reader.Read<int>();
			MaxDate = reader.Read<int>();
			OffsetRate = reader.Read<int>();
			OffsetPeer = reader.Read<InputPeerBase>();
			OffsetId = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}