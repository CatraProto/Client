using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MaskCoordsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("n")] public abstract int N { get; set; }

        [Newtonsoft.Json.JsonProperty("x")] public abstract double X { get; set; }

        [Newtonsoft.Json.JsonProperty("y")] public abstract double Y { get; set; }

        [Newtonsoft.Json.JsonProperty("zoom")] public abstract double Zoom { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}