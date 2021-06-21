using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class FileHashBase : IObject
	{
		public abstract int Offset { get; set; }
		public abstract int Limit { get; set; }
		public abstract byte[] Hash { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}