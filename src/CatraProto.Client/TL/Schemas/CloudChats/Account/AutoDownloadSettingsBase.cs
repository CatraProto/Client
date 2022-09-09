using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AutoDownloadSettingsBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("low")] public abstract CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Low { get; set; }

        [Newtonsoft.Json.JsonProperty("medium")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase Medium { get; set; }

        [Newtonsoft.Json.JsonProperty("high")] public abstract CatraProto.Client.TL.Schemas.CloudChats.AutoDownloadSettingsBase High { get; set; }

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