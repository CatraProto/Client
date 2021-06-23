using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotCommand : BotCommandBase
	{
		public static int ConstructorId { get; } = -1032140601;
		public override string Command { get; set; }
		public override string Description { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Command);
			writer.Write(Description);
		}

		public override void Deserialize(Reader reader)
		{
			Command = reader.Read<string>();
			Description = reader.Read<string>();
		}
	}
}