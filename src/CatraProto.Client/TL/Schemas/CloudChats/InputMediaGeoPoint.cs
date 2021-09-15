using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaGeoPoint : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
	{


        public static int StaticConstructorId { get => -104578748; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("geo_point")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(GeoPoint);

		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();

		}
				
		public override string ToString()
		{
		    return "inputMediaGeoPoint";
		}
	}
}