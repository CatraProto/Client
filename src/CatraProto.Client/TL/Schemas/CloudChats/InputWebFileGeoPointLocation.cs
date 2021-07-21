using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputWebFileGeoPointLocation : CatraProto.Client.TL.Schemas.CloudChats.InputWebFileLocationBase
	{


        public static int StaticConstructorId { get => -1625153079; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("geo_point")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase GeoPoint { get; set; }

[JsonPropertyName("access_hash")]
		public override long AccessHash { get; set; }

[JsonPropertyName("w")]
		public int W { get; set; }

[JsonPropertyName("h")]
		public int H { get; set; }

[JsonPropertyName("zoom")]
		public int Zoom { get; set; }

[JsonPropertyName("scale")]
		public int Scale { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(GeoPoint);
			writer.Write(AccessHash);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Zoom);
			writer.Write(Scale);

		}

		public override void Deserialize(Reader reader)
		{
			GeoPoint = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGeoPointBase>();
			AccessHash = reader.Read<long>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Zoom = reader.Read<int>();
			Scale = reader.Read<int>();

		}
	}
}