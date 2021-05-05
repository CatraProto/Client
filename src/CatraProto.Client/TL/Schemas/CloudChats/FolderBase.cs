using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class FolderBase : IObject
    {
        public abstract bool AutofillNewBroadcasts { get; set; }
        public abstract bool AutofillPublicGroups { get; set; }
        public abstract bool AutofillNewCorrespondents { get; set; }
        public abstract int Id { get; set; }
        public abstract string Title { get; set; }
        public abstract ChatPhotoBase Photo { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}