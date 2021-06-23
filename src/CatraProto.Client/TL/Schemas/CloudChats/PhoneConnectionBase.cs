using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class PhoneConnectionBase : IObject
	{
		public abstract long Id { get; set; }
		public abstract string Ip { get; set; }
		public abstract string Ipv6 { get; set; }
		public abstract int Port { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}