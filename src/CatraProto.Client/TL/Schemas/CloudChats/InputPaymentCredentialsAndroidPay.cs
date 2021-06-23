using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPaymentCredentialsAndroidPay : InputPaymentCredentialsBase
	{
		public static int ConstructorId { get; } = -905587442;
		public DataJSONBase PaymentToken { get; set; }
		public string GoogleTransactionId { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(PaymentToken);
			writer.Write(GoogleTransactionId);
		}

		public override void Deserialize(Reader reader)
		{
			PaymentToken = reader.Read<DataJSONBase>();
			GoogleTransactionId = reader.Read<string>();
		}
	}
}