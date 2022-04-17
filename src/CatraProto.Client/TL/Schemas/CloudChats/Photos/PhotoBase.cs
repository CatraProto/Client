using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public abstract class PhotoBase : IObject
    {

[Newtonsoft.Json.JsonProperty("photo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase PhotoField { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public abstract List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
