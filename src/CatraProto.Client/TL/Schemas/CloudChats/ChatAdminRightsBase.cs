using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatAdminRightsBase : IObject
    {
		public abstract bool ChangeInfo { get; set; }
		public abstract bool PostMessages { get; set; }
		public abstract bool EditMessages { get; set; }
		public abstract bool DeleteMessages { get; set; }
		public abstract bool BanUsers { get; set; }
		public abstract bool InviteUsers { get; set; }
		public abstract bool PinMessages { get; set; }
		public abstract bool AddAdmins { get; set; }
		public abstract bool Anonymous { get; set; }
		public abstract bool ManageCall { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
