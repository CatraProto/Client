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


        public static int StaticConstructorId { get => 1457575028; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("geo")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}