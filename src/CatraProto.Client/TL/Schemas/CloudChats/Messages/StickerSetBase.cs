using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class StickerSetBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
