using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageTableCellBase : IObject
    {
		public abstract bool Header { get; set; }
		public abstract bool AlignCenter { get; set; }
		public abstract bool AlignRight { get; set; }
		public abstract bool ValignMiddle { get; set; }
		public abstract bool ValignBottom { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }
		public abstract int? Colspan { get; set; }
		public abstract int? Rowspan { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
