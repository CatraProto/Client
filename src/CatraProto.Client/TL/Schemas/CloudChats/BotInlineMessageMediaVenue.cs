using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInlineMessageMediaVenue : CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ReplyMarkup = 1 << 2
		}

        public static int StaticConstructorId { get => -1970903652; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("geo")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("address")]
		public string Address { get; set; }

[Newtonsoft.Json.JsonProperty("provider")]
		public string Provider { get; set; }

[Newtonsoft.Json.JsonProperty("venue_id")]
		public string VenueId { get; set; }

[Newtonsoft.Json.JsonProperty("venue_type")]
		public string VenueType { get; set; }

[Newtonsoft.Json.JsonProperty("reply_markup")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }


        #nullable enable
 public BotInlineMessageMediaVenue (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo,string title,string address,string provider,string venueId,string venueType)
{
 Geo = geo;
Title = title;
Address = address;
Provider = provider;
VenueId = venueId;
VenueType = venueType;
 
}
#nullable disable
        internal BotInlineMessageMediaVenue() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
				
		public override string ToString()
		{
		    return "botInlineMessageMediaVenue";
		}
	}
}