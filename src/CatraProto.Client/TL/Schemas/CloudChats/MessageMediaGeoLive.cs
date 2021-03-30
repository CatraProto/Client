using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaGeoLive : MessageMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Heading = 1 << 0,
			ProximityNotificationRadius = 1 << 1
		}

        public static int ConstructorId { get; } = -1186937242;
		public int Flags { get; set; }
		public GeoPointBase Geo { get; set; }
		public int? Heading { get; set; }
		public int Period { get; set; }
		public int? ProximityNotificationRadius { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Heading == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ProximityNotificationRadius == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
			Geo = reader.Read<GeoPointBase>();
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
	}
}