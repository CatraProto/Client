using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class PageCaptionBase : IObject
	{
		public abstract RichTextBase Text { get; set; }
		public abstract RichTextBase Credit { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}