using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class Takeout : TakeoutBase
	{
		public static int ConstructorId { get; } = 1304052993;
		public override long Id { get; set; }

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
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
		}
	}
}