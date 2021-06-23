using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class ExportedMessageLinkBase : IObject
	{
		public abstract string Link { get; set; }
		public abstract string Html { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}