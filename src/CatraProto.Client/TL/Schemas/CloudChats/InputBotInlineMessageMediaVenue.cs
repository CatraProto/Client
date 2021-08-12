using System;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineMessageMediaVenue : InputBotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ReplyMarkup = 1 << 2
		}

        public static int StaticConstructorId { get => 1098628881; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("geo_point")]
		public InputGeoPointBase GeoPoint { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("address")]
		public string Address { get; set; }

[JsonPropertyName("provider")]
		public string Provider { get; set; }

[JsonPropertyName("venue_id")]
		public string VenueId { get; set; }

[JsonPropertyName("venue_type")]
		public string VenueType { get; set; }

[JsonPropertyName("reply_markup")]
		public override ReplyMarkupBase ReplyMarkup { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(GeoPoint);
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
			GeoPoint = reader.Read<InputGeoPointBase>();
			Title = reader.Read<string>();
			Address = reader.Read<string>();
			Provider = reader.Read<string>();
			VenueId = reader.Read<string>();
			VenueType = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<ReplyMarkupBase>();
			}
		}

		public override string ToString()
		{
			return "inputBotInlineMessageMediaVenue";
		}
	}
}