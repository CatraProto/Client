using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class InputWebDocumentBase : IObject
	{
		public abstract string Url { get; set; }
		public abstract int Size { get; set; }
		public abstract string MimeType { get; set; }
		public abstract IList<DocumentAttributeBase> Attributes { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}