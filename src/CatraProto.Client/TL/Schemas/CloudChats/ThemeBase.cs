using CatraProto.TL;
using System.Collections.Generic;
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

[Newtonsoft.Json.JsonProperty("id")]
		public abstract long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public abstract long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("slug")]
		public abstract string Slug { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public abstract string Title { get; set; }

[Newtonsoft.Json.JsonProperty("document")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase Settings { get; set; }

[Newtonsoft.Json.JsonProperty("installs_count")]
		public abstract int InstallsCount { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
