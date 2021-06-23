using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class InputSingleMediaBase : IObject
	{
		public abstract InputMediaBase Media { get; set; }
		public abstract long RandomId { get; set; }
		public abstract string Message { get; set; }
		public abstract IList<MessageEntityBase> Entities { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}