using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StickerSetBase : IObject
    {

[JsonPropertyName("archived")]
		public abstract bool Archived { get; set; }

[JsonPropertyName("official")]
		public abstract bool Official { get; set; }

[JsonPropertyName("masks")]
		public abstract bool Masks { get; set; }

[JsonPropertyName("animated")]
		public abstract bool Animated { get; set; }

[JsonPropertyName("installed_date")]
		public abstract int? InstalledDate { get; set; }

[JsonPropertyName("id")]
		public abstract long Id { get; set; }

[JsonPropertyName("access_hash")]
		public abstract long AccessHash { get; set; }

[JsonPropertyName("title")]
		public abstract string Title { get; set; }

[JsonPropertyName("short_name")]
		public abstract string ShortName { get; set; }

[JsonPropertyName("thumb")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase Thumb { get; set; }

[JsonPropertyName("thumb_dc_id")]
		public abstract int? ThumbDcId { get; set; }

[JsonPropertyName("count")]
		public abstract int Count { get; set; }

[JsonPropertyName("hash")]
		public abstract int Hash { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
