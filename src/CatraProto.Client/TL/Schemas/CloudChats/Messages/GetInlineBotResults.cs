using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetInlineBotResults : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			GeoPoint = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1364105629; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("bot")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

[JsonPropertyName("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[JsonPropertyName("geo_point")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

[JsonPropertyName("query")]
		public string Query { get; set; }

[JsonPropertyName("offset")]
		public string Offset { get; set; }


		public void UpdateFlags() 
		{
			Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Bot);
			writer.Write(Peer);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(GeoPoint);
			}

			writer.Write(Query);
			writer.Write(Offset);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Bot = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
			}

			Query = reader.Read<string>();
			Offset = reader.Read<string>();

		}
	}
}