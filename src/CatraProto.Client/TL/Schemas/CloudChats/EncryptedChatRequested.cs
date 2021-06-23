using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedChatRequested : EncryptedChatBase
	{
		[Flags]
		public enum FlagsEnum
		{
			FolderId = 1 << 0
		}

		public static int ConstructorId { get; } = 1651608194;
		public int Flags { get; set; }
		public int? FolderId { get; set; }
		public override int Id { get; set; }
		public long AccessHash { get; set; }
		public int Date { get; set; }
		public int AdminId { get; set; }
		public int ParticipantId { get; set; }
		public byte[] GA { get; set; }

		public override void UpdateFlags()
		{
			Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(FolderId.Value);
			}

			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(GA);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				FolderId = reader.Read<int>();
			}

			Id = reader.Read<int>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<int>();
			ParticipantId = reader.Read<int>();
			GA = reader.Read<byte[]>();
		}
	}
}