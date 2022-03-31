using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelLocation : CatraProto.Client.TL.Schemas.CloudChats.ChannelLocationBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 547062491; }
        
[Newtonsoft.Json.JsonProperty("geo_point")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase GeoPoint { get; set; }

[Newtonsoft.Json.JsonProperty("address")]
		public string Address { get; set; }


        #nullable enable
 public ChannelLocation (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geoPoint,string address)
{
 GeoPoint = geoPoint;
Address = address;
 
}
#nullable disable
        internal ChannelLocation() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(GeoPoint);
			writer.Write(Address);

		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			Address = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "channelLocation";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}