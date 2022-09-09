using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class JSONObjectValueBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("key")] public abstract string Key { get; set; }

        [Newtonsoft.Json.JsonProperty("value")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.JSONValueBase Value { get; set; }

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