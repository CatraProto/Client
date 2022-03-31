using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaGeo : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1457575028; }
        
[Newtonsoft.Json.JsonProperty("geo")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }


        #nullable enable
 public MessageMediaGeo (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo)
{
 Geo = geo;
 
}
#nullable disable
        internal MessageMediaGeo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Geo);

		}

		public override void Deserialize(Reader reader)
		{
			Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();

		}
		
		public override string ToString()
		{
		    return "messageMediaGeo";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}