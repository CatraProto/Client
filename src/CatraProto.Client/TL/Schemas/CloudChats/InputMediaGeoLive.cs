using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaGeoLive : InputMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Stopped = 1 << 0,
			Heading = 1 << 2,
			Period = 1 << 1,
			ProximityNotificationRadius = 1 << 3
		}

        public static int ConstructorId { get; } = -1759532989;
		public int Flags { get; set; }
		public bool Stopped { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }
		public int? Heading { get; set; }
		public int? Period { get; set; }
		public int? ProximityNotificationRadius { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Stopped ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Heading == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Period == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ProximityNotificationRadius == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(GeoPoint);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Heading.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Period.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ProximityNotificationRadius.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Stopped = FlagsHelper.IsFlagSet(Flags, 0);
			GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Heading = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Period = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ProximityNotificationRadius = reader.Read<int>();
			}


		}
	}
}