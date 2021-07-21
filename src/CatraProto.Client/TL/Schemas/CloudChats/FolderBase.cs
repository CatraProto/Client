using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FolderBase : IObject
    {

[JsonPropertyName("autofill_new_broadcasts")]
		public abstract bool AutofillNewBroadcasts { get; set; }

[JsonPropertyName("autofill_public_groups")]
		public abstract bool AutofillPublicGroups { get; set; }

[JsonPropertyName("autofill_new_correspondents")]
		public abstract bool AutofillNewCorrespondents { get; set; }

[JsonPropertyName("id")]
		public abstract int Id { get; set; }

[JsonPropertyName("title")]
		public abstract string Title { get; set; }

[JsonPropertyName("photo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase Photo { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
