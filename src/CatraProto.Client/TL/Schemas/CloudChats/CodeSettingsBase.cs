using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public abstract class CodeSettingsBase : IObject
	{
		public abstract bool AllowFlashcall { get; set; }
		public abstract bool CurrentNumber { get; set; }
		public abstract bool AllowAppHash { get; set; }

		public abstract void UpdateFlags();
		public abstract void Deserialize(Reader reader);
		public abstract void Serialize(Writer writer);
	}
}