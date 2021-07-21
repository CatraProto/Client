using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputStickerSetItemBase : IObject
    {

[JsonPropertyName("document")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

[JsonPropertyName("emoji")]
		public abstract string Emoji { get; set; }

[JsonPropertyName("mask_coords")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
