using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotInlineQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Geo = 1 << 0
		}

        public static int StaticConstructorId { get => 1417832080; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("query_id")]
		public long QueryId { get; set; }

[JsonPropertyName("user_id")]
		public int UserId { get; set; }

[JsonPropertyName("query")]
		public string Query { get; set; }

[JsonPropertyName("geo")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

[JsonPropertyName("offset")]
		public string Offset { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Geo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			writer.Write(UserId);
			writer.Write(Query);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Geo);
			}

			writer.Write(Offset);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			QueryId = reader.Read<long>();
			UserId = reader.Read<int>();
			Query = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			}

			Offset = reader.Read<string>();

		}
	}
}