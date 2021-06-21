using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReceivedMessages : IMethod
	{
		public static int ConstructorId { get; } = 94983360;
		public int MaxId { get; set; }

		public Type Type { get; init; } = typeof(ReceivedNotifyMessageBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MaxId);
		}

		public void Deserialize(Reader reader)
		{
			MaxId = reader.Read<int>();
		}
	}
}