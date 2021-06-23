using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputSecureFile : InputSecureFileBase
	{
		public static int ConstructorId { get; } = 1399317950;
		public override long Id { get; set; }
		public long AccessHash { get; set; }

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
			writer.Write(AccessHash);
		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
		}
	}
}