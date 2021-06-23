using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class SetBotUpdatesStatus : IMethod
	{
		public static int ConstructorId { get; } = -333262899;
		public int PendingUpdatesCount { get; set; }
		public string Message { get; set; }

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

			writer.Write(PendingUpdatesCount);
			writer.Write(Message);
		}

		public void Deserialize(Reader reader)
		{
			PendingUpdatesCount = reader.Read<int>();
			Message = reader.Read<string>();
		}
	}
}