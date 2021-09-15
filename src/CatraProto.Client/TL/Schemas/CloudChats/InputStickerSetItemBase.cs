using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputStickerSetItemBase : IObject
    {

[Newtonsoft.Json.JsonProperty("document")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

[Newtonsoft.Json.JsonProperty("emoji")]
		public abstract string Emoji { get; set; }

[Newtonsoft.Json.JsonProperty("mask_coords")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
