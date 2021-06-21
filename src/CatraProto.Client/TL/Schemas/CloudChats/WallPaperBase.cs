using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WallPaperBase : IObject
    {
        public abstract bool Default { get; set; }
        public abstract bool Dark { get; set; }
        public abstract WallPaperSettingsBase Settings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}