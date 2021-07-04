using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PhoneCall : PhoneCallBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			P2pAllowed = 1 << 5,
			Video = 1 << 6
		}

        public static int ConstructorId { get; } = -2025673089;
		public int Flags { get; set; }
		public bool P2pAllowed { get; set; }
		public bool Video { get; set; }
		public override long Id { get; set; }
		public long AccessHash { get; set; }
		public int Date { get; set; }
		public int AdminId { get; set; }
		public int ParticipantId { get; set; }
		public byte[] GAOrB { get; set; }
		public long KeyFingerprint { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase> Connections { get; set; }
		public int StartDate { get; set; }

		public override void UpdateFlags() 
		{
			Flags = P2pAllowed ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(GAOrB);
			writer.Write(KeyFingerprint);
			writer.Write(Protocol);
			writer.Write(Connections);
			writer.Write(StartDate);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			P2pAllowed = FlagsHelper.IsFlagSet(Flags, 5);
			Video = FlagsHelper.IsFlagSet(Flags, 6);
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<int>();
			ParticipantId = reader.Read<int>();
			GAOrB = reader.Read<byte[]>();
			KeyFingerprint = reader.Read<long>();
			Protocol = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();
			Connections = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase>();
			StartDate = reader.Read<int>();

		}
	}
}