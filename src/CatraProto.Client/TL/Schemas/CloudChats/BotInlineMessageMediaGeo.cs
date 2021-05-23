using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInlineMessageMediaGeo : BotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Heading = 1 << 0,
			Period = 1 << 1,
			ProximityNotificationRadius = 1 << 3,
			ReplyMarkup = 1 << 2
		}

        public static int ConstructorId { get; } = 85477117;
		public int Flags { get; set; }
		public GeoPointBase Geo { get; set; }
		public int? Heading { get; set; }
		public int? Period { get; set; }
		public int? ProximityNotificationRadius { get; set; }
		public override ReplyMarkupBase ReplyMarkup { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Heading == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Period == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ProximityNotificationRadius == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

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

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Period.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ProximityNotificationRadius.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
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

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Period = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ProximityNotificationRadius = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<ReplyMarkupBase>();
			}


		}
	}
}