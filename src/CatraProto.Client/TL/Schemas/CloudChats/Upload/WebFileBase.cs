using CatraProto.Client.TL.Schemas.CloudChats.Storage;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public abstract class WebFileBase : IObject
    {
		public abstract int Size { get; set; }
		public abstract string MimeType { get; set; }
		public abstract FileTypeBase FileType { get; set; }
		public abstract int Mtime { get; set; }
		public abstract byte[] Bytes { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
