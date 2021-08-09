using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MaskCoords : CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase
	{


        public static int StaticConstructorId { get => -1361650766; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("n")]
		public override int N { get; set; }

[JsonPropertyName("x")]
		public override double X { get; set; }

[JsonPropertyName("y")]
		public override double Y { get; set; }

[JsonPropertyName("zoom")]
		public override double Zoom { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(N);
			writer.Write(X);
			writer.Write(Y);
			writer.Write(Zoom);

		}

		public override void Deserialize(Reader reader)
		{
			N = reader.Read<int>();
			X = reader.Read<double>();
			Y = reader.Read<double>();
			Zoom = reader.Read<double>();

		}
	}
}