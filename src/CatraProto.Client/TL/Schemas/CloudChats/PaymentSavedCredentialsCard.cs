using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PaymentSavedCredentialsCard : PaymentSavedCredentialsBase
	{
		public static int ConstructorId { get; } = -842892769;
		public override string Id { get; set; }
		public override string Title { get; set; }

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
			writer.Write(Title);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<string>();
			Title = reader.Read<string>();
		}
	}
}