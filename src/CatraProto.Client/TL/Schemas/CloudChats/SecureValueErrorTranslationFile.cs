using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueErrorTranslationFile : SecureValueErrorBase
	{
		public static int ConstructorId { get; } = -1592506512;
		public override SecureValueTypeBase Type { get; set; }
		public byte[] FileHash { get; set; }
		public override string Text { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(FileHash);
			writer.Write(Text);
		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<SecureValueTypeBase>();
			FileHash = reader.Read<byte[]>();
			Text = reader.Read<string>();
		}
	}
}