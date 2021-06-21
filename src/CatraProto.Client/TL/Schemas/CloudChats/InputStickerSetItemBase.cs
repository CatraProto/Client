using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputStickerSetItemBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }
		public abstract string Emoji { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.MaskCoordsBase MaskCoords { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
