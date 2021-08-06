using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class GameBase : IObject
    {

[JsonPropertyName("id")]
		public abstract long Id { get; set; }

[JsonPropertyName("access_hash")]
		public abstract long AccessHash { get; set; }

[JsonPropertyName("short_name")]
		public abstract string ShortName { get; set; }

[JsonPropertyName("title")]
		public abstract string Title { get; set; }

[JsonPropertyName("description")]
		public abstract string Description { get; set; }

[JsonPropertyName("photo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

[JsonPropertyName("document")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
