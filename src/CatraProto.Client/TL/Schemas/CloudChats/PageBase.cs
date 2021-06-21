using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageBase : IObject
    {
		public abstract bool Part { get; set; }
		public abstract bool Rtl { get; set; }
		public abstract bool V2 { get; set; }
		public abstract string Url { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Blocks { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }
		public abstract int? Views { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
