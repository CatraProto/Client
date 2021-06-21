using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SentEmailCode : SentEmailCodeBase
	{
		public static int ConstructorId { get; } = -2128640689;
		public override string EmailPattern { get; set; }
		public override int Length { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(EmailPattern);
			writer.Write(Length);
		}

		public override void Deserialize(Reader reader)
		{
			EmailPattern = reader.Read<string>();
			Length = reader.Read<int>();
		}
	}
}