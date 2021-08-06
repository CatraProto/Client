using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ThemeBase : IObject
    {

[JsonPropertyName("creator")]
		public abstract bool Creator { get; set; }

[JsonPropertyName("default")]
		public abstract bool Default { get; set; }

[JsonPropertyName("id")]
		public abstract long Id { get; set; }

[JsonPropertyName("access_hash")]
		public abstract long AccessHash { get; set; }

[JsonPropertyName("slug")]
		public abstract string Slug { get; set; }

[JsonPropertyName("title")]
		public abstract string Title { get; set; }

[JsonPropertyName("document")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[JsonPropertyName("settings")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase Settings { get; set; }

[JsonPropertyName("installs_count")]
		public abstract int InstallsCount { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
