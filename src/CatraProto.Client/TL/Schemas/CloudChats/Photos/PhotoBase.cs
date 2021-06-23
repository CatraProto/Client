using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public abstract class PhotoBase : IObject
	{
		public abstract CloudChats.PhotoBase Photo_ { get; set; }
		public abstract IList<UserBase> Users { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}