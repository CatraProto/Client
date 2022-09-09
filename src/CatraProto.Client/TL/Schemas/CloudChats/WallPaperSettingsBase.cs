using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WallPaperSettingsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("blur")] public abstract bool Blur { get; set; }

        [Newtonsoft.Json.JsonProperty("motion")]
        public abstract bool Motion { get; set; }

        [Newtonsoft.Json.JsonProperty("background_color")]
        public abstract int? BackgroundColor { get; set; }

        [Newtonsoft.Json.JsonProperty("second_background_color")]
        public abstract int? SecondBackgroundColor { get; set; }

        [Newtonsoft.Json.JsonProperty("third_background_color")]
        public abstract int? ThirdBackgroundColor { get; set; }

        [Newtonsoft.Json.JsonProperty("fourth_background_color")]
        public abstract int? FourthBackgroundColor { get; set; }

        [Newtonsoft.Json.JsonProperty("intensity")]
        public abstract int? Intensity { get; set; }

        [Newtonsoft.Json.JsonProperty("rotation")]
        public abstract int? Rotation { get; set; }

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