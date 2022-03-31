using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class GeoPoint : CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			AccuracyRadius = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1297942941; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("long")]
		public double Long { get; set; }

[Newtonsoft.Json.JsonProperty("lat")]
		public double Lat { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("accuracy_radius")]
		public int? AccuracyRadius { get; set; }


        #nullable enable
 public GeoPoint (double llong,double lat,long accessHash)
{
 Long = llong;
Lat = lat;
AccessHash = accessHash;
 
}
#nullable disable
        internal GeoPoint() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = AccuracyRadius == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
		
		public override string ToString()
		{
		    return "geoPoint";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}