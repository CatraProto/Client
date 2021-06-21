using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EncryptedChat : EncryptedChatBase
	{
		public static int ConstructorId { get; } = -94974410;
		public override int Id { get; set; }
		public long AccessHash { get; set; }
		public int Date { get; set; }
		public int AdminId { get; set; }
		public int ParticipantId { get; set; }
		public byte[] GAOrB { get; set; }
		public long KeyFingerprint { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Date);
			writer.Write(AdminId);
			writer.Write(ParticipantId);
			writer.Write(GAOrB);
			writer.Write(KeyFingerprint);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			AccessHash = reader.Read<long>();
			Date = reader.Read<int>();
			AdminId = reader.Read<int>();
			ParticipantId = reader.Read<int>();
			GAOrB = reader.Read<byte[]>();
			KeyFingerprint = reader.Read<long>();
		}
	}
}