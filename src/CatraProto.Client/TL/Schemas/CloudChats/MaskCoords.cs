using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MaskCoords : CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase
	{


        public static int StaticConstructorId { get => -1361650766; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("n")]
		public override int N { get; set; }

[Newtonsoft.Json.JsonProperty("x")]
		public override double X { get; set; }

[Newtonsoft.Json.JsonProperty("y")]
		public override double Y { get; set; }

[Newtonsoft.Json.JsonProperty("zoom")]
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
				
		public override string ToString()
		{
		    return "maskCoords";
		}
	}
}