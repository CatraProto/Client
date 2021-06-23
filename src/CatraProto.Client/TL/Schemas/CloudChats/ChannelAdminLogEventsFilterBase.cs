using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class ChannelAdminLogEventsFilterBase : IObject
	{
		public abstract bool Join { get; set; }
		public abstract bool Leave { get; set; }
		public abstract bool Invite { get; set; }
		public abstract bool Ban { get; set; }
		public abstract bool Unban { get; set; }
		public abstract bool Kick { get; set; }
		public abstract bool Unkick { get; set; }
		public abstract bool Promote { get; set; }
		public abstract bool Demote { get; set; }
		public abstract bool Info { get; set; }
		public abstract bool Settings { get; set; }
		public abstract bool Pinned { get; set; }
		public abstract bool Edit { get; set; }
		public abstract bool Delete { get; set; }
		public abstract bool GroupCall { get; set; }
		public abstract bool Invites { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}