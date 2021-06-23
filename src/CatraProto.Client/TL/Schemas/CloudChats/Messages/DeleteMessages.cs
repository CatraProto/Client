using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DeleteMessages : IMethod
	{
		[Flags]
		public enum FlagsEnum
		{
			Revoke = 1 << 0
		}

		public static int ConstructorId { get; } = -443640366;
		public int Flags { get; set; }
		public bool Revoke { get; set; }
		public IList<int> Id { get; set; }

		public Type Type { get; init; } = typeof(AffectedMessagesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
			Flags = Revoke ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Revoke = FlagsHelper.IsFlagSet(Flags, 0);
			Id = reader.ReadVector<int>();
		}
	}
}