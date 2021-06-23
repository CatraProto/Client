using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetInlineGameHighScores : IMethod
	{
		public static int ConstructorId { get; } = 258170395;
		public InputBotInlineMessageIDBase Id { get; set; }
		public InputUserBase UserId { get; set; }

		public Type Type { get; init; } = typeof(HighScoresBase);
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

			writer.Write(Id);
			writer.Write(UserId);
		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<InputBotInlineMessageIDBase>();
			UserId = reader.Read<InputUserBase>();
		}
	}
}