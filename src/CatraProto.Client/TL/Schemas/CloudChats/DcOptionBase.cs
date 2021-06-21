using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class DcOptionBase : IObject
	{
		public abstract bool Ipv6 { get; set; }
		public abstract bool MediaOnly { get; set; }
		public abstract bool TcpoOnly { get; set; }
		public abstract bool Cdn { get; set; }
		public abstract bool Static { get; set; }
		public abstract int Id { get; set; }
		public abstract string IpAddress { get; set; }
		public abstract int Port { get; set; }
		public abstract byte[] Secret { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}