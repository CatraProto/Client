using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class VideoSizeBase : IObject
    {
		public abstract string Type { get; set; }
		public abstract FileLocationBase Location { get; set; }
		public abstract int W { get; set; }
		public abstract int H { get; set; }
		public abstract int Size { get; set; }
		public abstract double? VideoStartTs { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
