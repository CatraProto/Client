using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputGeoPoint : CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			AccuracyRadius = 1 << 0
		}

        public static int StaticConstructorId { get => 1210199983; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("lat")]
		public double Lat { get; set; }

[JsonPropertyName("long")]
		public double Long { get; set; }

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
			writer.Write(Lat);
			writer.Write(Long);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(AccuracyRadius.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Lat = reader.Read<double>();
			Long = reader.Read<double>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				AccuracyRadius = reader.Read<int>();
			}


		}
	}
}