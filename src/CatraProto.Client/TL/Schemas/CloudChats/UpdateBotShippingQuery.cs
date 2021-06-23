using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotShippingQuery : UpdateBase
	{
		public static int ConstructorId { get; } = -523384512;
		public long QueryId { get; set; }
		public int UserId { get; set; }
		public byte[] Payload { get; set; }
		public PostAddressBase ShippingAddress { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(QueryId);
			writer.Write(UserId);
			writer.Write(Payload);
			writer.Write(ShippingAddress);
		}

		public override void Deserialize(Reader reader)
		{
			QueryId = reader.Read<long>();
			UserId = reader.Read<int>();
			Payload = reader.Read<byte[]>();
			ShippingAddress = reader.Read<PostAddressBase>();
		}
	}
}