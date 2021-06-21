using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCallWaiting : PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Video = 1 << 6,
			ReceiveDate = 1 << 0
		}

		public static int ConstructorId { get; } = 462375633;
		public int Flags { get; set; }
		public bool Video { get; set; }
		public override long Id { get; set; }
		public long AccessHash { get; set; }
		public int Date { get; set; }
		public int AdminId { get; set; }
		public int ParticipantId { get; set; }
		public PhoneCallProtocolBase Protocol { get; set; }
		public int? ReceiveDate { get; set; }

		public override void UpdateFlags()
		{
			Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = ReceiveDate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(Protocol);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ReceiveDate.Value);
			}
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Video = FlagsHelper.IsFlagSet(Flags, 6);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<int>();
			ParticipantId = reader.Read<int>();
			Protocol = reader.Read<PhoneCallProtocolBase>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				ReceiveDate = reader.Read<int>();
			}
		}
	}
}