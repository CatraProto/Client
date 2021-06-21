using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInlineMessageMediaVenue : BotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ReplyMarkup = 1 << 2
		}

        public static int ConstructorId { get; } = -1970903652;
		public int Flags { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }
		public string Title { get; set; }
		public string Address { get; set; }
		public string Provider { get; set; }
		public string VenueId { get; set; }
		public string VenueType { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }

		public override void UpdateFlags() 
		{
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Geo);
			writer.Write(Title);
			writer.Write(Address);
			writer.Write(Provider);
			writer.Write(VenueId);
			writer.Write(VenueType);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			Title = reader.Read<string>();
			Address = reader.Read<string>();
			Provider = reader.Read<string>();
			VenueId = reader.Read<string>();
			VenueType = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
			}


		}
	}
}