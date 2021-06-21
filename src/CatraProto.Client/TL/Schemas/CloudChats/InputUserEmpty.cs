using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputUserEmpty : InputUserBase
	{
		public static int ConstructorId { get; } = -1182234929;

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
		}

		public override void Deserialize(Reader reader)
		{
		}
	}
}