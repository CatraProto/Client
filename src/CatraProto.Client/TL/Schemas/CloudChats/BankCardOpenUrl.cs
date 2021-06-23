using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BankCardOpenUrl : BankCardOpenUrlBase
	{
		public static int ConstructorId { get; } = -177732982;
		public override string Url { get; set; }
		public override string Name { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Url);
			writer.Write(Name);
		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();
			Name = reader.Read<string>();
		}
	}
}