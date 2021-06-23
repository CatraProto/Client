using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsSaved : InputPaymentCredentialsBase
	{
		public static int ConstructorId { get; } = -1056001329;
		public string Id { get; set; }
		public byte[] TmpPassword { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Id);
			writer.Write(TmpPassword);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			TmpPassword = reader.Read<byte[]>();
		}
	}
}