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


        public static int StaticConstructorId { get => 547062491; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("geo_point")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase GeoPoint { get; set; }

[Newtonsoft.Json.JsonProperty("address")]
		public string Address { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}