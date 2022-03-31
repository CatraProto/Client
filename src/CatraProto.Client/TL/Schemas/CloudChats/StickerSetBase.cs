using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StickerSetBase : IObject
    {

[Newtonsoft.Json.JsonProperty("archived")]
		public abstract bool Archived { get; set; }

[Newtonsoft.Json.JsonProperty("official")]
		public abstract bool Official { get; set; }

[Newtonsoft.Json.JsonProperty("masks")]
		public abstract bool Masks { get; set; }

[Newtonsoft.Json.JsonProperty("animated")]
		public abstract bool Animated { get; set; }

[Newtonsoft.Json.JsonProperty("videos")]
		public abstract bool Videos { get; set; }

[Newtonsoft.Json.JsonProperty("installed_date")]
		public abstract int? InstalledDate { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public abstract long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public abstract long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public abstract string Title { get; set; }

[Newtonsoft.Json.JsonProperty("short_name")]
		public abstract string ShortName { get; set; }

[Newtonsoft.Json.JsonProperty("thumbs")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Thumbs { get; set; }

[Newtonsoft.Json.JsonProperty("thumb_dc_id")]
		public abstract int? ThumbDcId { get; set; }

[Newtonsoft.Json.JsonProperty("thumb_version")]
		public abstract int? ThumbVersion { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public abstract int Count { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public abstract int Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
