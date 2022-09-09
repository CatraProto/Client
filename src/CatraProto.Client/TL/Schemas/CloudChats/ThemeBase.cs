using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ThemeBase : IObject
    {
        [Newtonsoft.Json.JsonProperty("creator")]
        public abstract bool Creator { get; set; }

        [Newtonsoft.Json.JsonProperty("default")]
        public abstract bool Default { get; set; }

        [Newtonsoft.Json.JsonProperty("for_chat")]
        public abstract bool ForChat { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public abstract long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public abstract long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("slug")] public abstract string Slug { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public abstract string Title { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("document")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("settings")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase> Settings { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("emoticon")]
        public abstract string Emoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("installs_count")]
        public abstract int? InstallsCount { get; set; }

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