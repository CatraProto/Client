using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class MaskCoordsBase : IObject
    {
        public abstract int N { get; set; }
        public abstract double X { get; set; }
        public abstract double Y { get; set; }
        public abstract double Zoom { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}