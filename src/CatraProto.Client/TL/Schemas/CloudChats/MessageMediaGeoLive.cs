using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaGeoLive : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Heading = 1 << 0,
			ProximityNotificationRadius = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1186937242; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("geo")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

[Newtonsoft.Json.JsonProperty("heading")]
		public int? Heading { get; set; }

[Newtonsoft.Json.JsonProperty("period")]
		public int Period { get; set; }

[Newtonsoft.Json.JsonProperty("proximity_notification_radius")]
		public int? ProximityNotificationRadius { get; set; }


        #nullable enable
 public MessageMediaGeoLive (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo,int period)
{
 Geo = geo;
Period = period;
 
}
#nullable disable
        internal MessageMediaGeoLive() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Heading == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ProximityNotificationRadius == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Geo);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Heading.Value);
			}

			writer.Write(Period);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ProximityNotificationRadius.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Heading = reader.Read<int>();
			}

			Period = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ProximityNotificationRadius = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "messageMediaGeoLive";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}