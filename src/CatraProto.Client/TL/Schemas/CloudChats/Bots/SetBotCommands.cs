using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
	public partial class SetBotCommands : IMethod
	{
		public static int ConstructorId { get; } = -2141370634;
		public IList<BotCommandBase> Commands { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Commands);
		}

		public void Deserialize(Reader reader)
		{
			Commands = reader.ReadVector<BotCommandBase>();
		}
	}
}