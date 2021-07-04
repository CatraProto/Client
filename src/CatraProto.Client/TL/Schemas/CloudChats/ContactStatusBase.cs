using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ContactStatusBase : IObject
    {
		public abstract int UserId { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
