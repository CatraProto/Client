using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AuthorizationBase : IObject
    {
		public abstract bool Current { get; set; }
		public abstract bool OfficialApp { get; set; }
		public abstract bool PasswordPending { get; set; }
		public abstract long Hash { get; set; }
		public abstract string DeviceModel { get; set; }
		public abstract string Platform { get; set; }
		public abstract string SystemVersion { get; set; }
		public abstract int ApiId { get; set; }
		public abstract string AppName { get; set; }
		public abstract string AppVersion { get; set; }
		public abstract int DateCreated { get; set; }
		public abstract int DateActive { get; set; }
		public abstract string Ip { get; set; }
		public abstract string Country { get; set; }
		public abstract string Region { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
