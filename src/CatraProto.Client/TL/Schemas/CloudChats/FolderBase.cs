using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FolderBase : IObject
    {

[Newtonsoft.Json.JsonProperty("autofill_new_broadcasts")]
		public abstract bool AutofillNewBroadcasts { get; set; }

[Newtonsoft.Json.JsonProperty("autofill_public_groups")]
		public abstract bool AutofillPublicGroups { get; set; }

[Newtonsoft.Json.JsonProperty("autofill_new_correspondents")]
		public abstract bool AutofillNewCorrespondents { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public abstract int Id { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public abstract string Title { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase Photo { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
