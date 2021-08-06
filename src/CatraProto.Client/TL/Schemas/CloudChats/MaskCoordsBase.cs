using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MaskCoordsBase : IObject
    {

[JsonPropertyName("n")]
		public abstract int N { get; set; }

[JsonPropertyName("x")]
		public abstract double X { get; set; }

[JsonPropertyName("y")]
		public abstract double Y { get; set; }

[JsonPropertyName("zoom")]
		public abstract double Zoom { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
