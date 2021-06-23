using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInfo : BotInfoBase
	{
		public static int ConstructorId { get; } = -1729618630;
		public override int UserId { get; set; }
		public override string Description { get; set; }
		public override IList<BotCommandBase> Commands { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(UserId);
			writer.Write(Description);
			writer.Write(Commands);
		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Description = reader.Read<string>();
			Commands = reader.ReadVector<BotCommandBase>();
		}
	}
}