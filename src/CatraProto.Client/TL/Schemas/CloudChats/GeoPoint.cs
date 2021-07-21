using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GeoPoint : CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			AccuracyRadius = 1 << 0
		}

        public static int StaticConstructorId { get => -1297942941; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("long")]
		public double Long { get; set; }

[JsonPropertyName("lat")]
		public double Lat { get; set; }

[JsonPropertyName("access_hash")]
		public long AccessHash { get; set; }

[JsonPropertyName("accuracy_radius")]
		public int? AccuracyRadius { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = AccuracyRadius == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Long);
			writer.Write(Lat);
			writer.Write(AccessHash);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(AccuracyRadius.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Long = reader.Read<double>();
			Lat = reader.Read<double>();
			AccessHash = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				AccuracyRadius = reader.Read<int>();
			}


		}
	}
}