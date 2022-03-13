using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class EditLocation : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1491484525; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("geo_point")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

[Newtonsoft.Json.JsonProperty("address")]
		public string Address { get; set; }

        
        #nullable enable
 public EditLocation (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase geoPoint,string address)
{
 Channel = channel;
GeoPoint = geoPoint;
Address = address;
 
}
#nullable disable
                
        internal EditLocation() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(GeoPoint);
			writer.Write(Address);

		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
			GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
			Address = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "channels.editLocation";
		}
	}
}