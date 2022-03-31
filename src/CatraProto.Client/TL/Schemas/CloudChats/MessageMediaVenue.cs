using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaVenue : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 784356159; }
        
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


        #nullable enable
 public MessageMediaVenue (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo,string title,string address,string provider,string venueId,string venueType)
{
 Geo = geo;
Title = title;
Address = address;
Provider = provider;
VenueId = venueId;
VenueType = venueType;
 
}
#nullable disable
        internal MessageMediaVenue() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Geo);
			writer.Write(Title);
			writer.Write(Address);
			writer.Write(Provider);
			writer.Write(VenueId);
			writer.Write(VenueType);

		}

		public override void Deserialize(Reader reader)
		{
			Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			Title = reader.Read<string>();
			Address = reader.Read<string>();
			Provider = reader.Read<string>();
			VenueId = reader.Read<string>();
			VenueType = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "messageMediaVenue";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}