using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class CheckChatInvite : IMethod
	{
		public static int ConstructorId { get; } = 1051570619;
		public string Hash { get; set; }

		public Type Type { get; init; } = typeof(ChatInviteBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<string>();
		}
	}
}