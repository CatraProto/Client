using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelParticipantCreator : ChannelParticipantBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Rank = 1 << 0
		}

		public static int ConstructorId { get; } = 1149094475;
		public int Flags { get; set; }
		public override int UserId { get; set; }
		public ChatAdminRightsBase AdminRights { get; set; }
		public string Rank { get; set; }

		public override void UpdateFlags()
		{
			Flags = Rank == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(AdminRights);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Rank);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			UserId = reader.Read<int>();
			AdminRights = reader.Read<ChatAdminRightsBase>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				Rank = reader.Read<string>();
			}
		}
	}
}