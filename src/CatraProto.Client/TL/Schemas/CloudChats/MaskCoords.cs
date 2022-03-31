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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1361650766; }
        
[Newtonsoft.Json.JsonProperty("n")]
		public sealed override int N { get; set; }

[Newtonsoft.Json.JsonProperty("x")]
		public sealed override double X { get; set; }

[Newtonsoft.Json.JsonProperty("y")]
		public sealed override double Y { get; set; }

[Newtonsoft.Json.JsonProperty("zoom")]
		public sealed override double Zoom { get; set; }


        #nullable enable
 public MaskCoords (int n,double x,double y,double zoom)
{
 N = n;
X = x;
Y = y;
Zoom = zoom;
 
}
#nullable disable
        internal MaskCoords() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}