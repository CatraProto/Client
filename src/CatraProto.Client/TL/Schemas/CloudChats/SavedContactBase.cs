using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class SavedContactBase : IObject
    {
        public abstract string Phone { get; set; }
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public abstract int Date { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}