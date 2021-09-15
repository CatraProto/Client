using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1271290010; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("folder_id")]
		public int? FolderId { get; set; }

[Newtonsoft.Json.JsonProperty("q")]
		public string Q { get; set; }

[Newtonsoft.Json.JsonProperty("filter")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

[Newtonsoft.Json.JsonProperty("min_date")]
		public int MinDate { get; set; }

[Newtonsoft.Json.JsonProperty("max_date")]
		public int MaxDate { get; set; }

[Newtonsoft.Json.JsonProperty("offset_rate")]
		public int OffsetRate { get; set; }

[Newtonsoft.Json.JsonProperty("offset_peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase OffsetPeer { get; set; }

[Newtonsoft.Json.JsonProperty("offset_id")]
		public int OffsetId { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
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
			Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
			MinDate = reader.Read<int>();
			MaxDate = reader.Read<int>();
			OffsetRate = reader.Read<int>();
			OffsetPeer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			OffsetId = reader.Read<int>();
			Limit = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.searchGlobal";
		}
	}
}