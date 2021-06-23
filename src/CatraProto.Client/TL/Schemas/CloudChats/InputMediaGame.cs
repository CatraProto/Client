using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaGame : InputMediaBase
	{
		public static int ConstructorId { get; } = -750828557;
		public InputGameBase Id { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Id);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<InputGameBase>();
		}
	}
}