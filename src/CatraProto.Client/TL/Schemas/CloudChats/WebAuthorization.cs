using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WebAuthorization : WebAuthorizationBase
	{
		public static int ConstructorId { get; } = -892779534;
		public override long Hash { get; set; }
		public override int BotId { get; set; }
		public override string Domain { get; set; }
		public override string Browser { get; set; }
		public override string Platform { get; set; }
		public override int DateCreated { get; set; }
		public override int DateActive { get; set; }
		public override string Ip { get; set; }
		public override string Region { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Hash);
			writer.Write(BotId);
			writer.Write(Domain);
			writer.Write(Browser);
			writer.Write(Platform);
			writer.Write(DateCreated);
			writer.Write(DateActive);
			writer.Write(Ip);
			writer.Write(Region);
		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<long>();
			BotId = reader.Read<int>();
			Domain = reader.Read<string>();
			Browser = reader.Read<string>();
			Platform = reader.Read<string>();
			DateCreated = reader.Read<int>();
			DateActive = reader.Read<int>();
			Ip = reader.Read<string>();
			Region = reader.Read<string>();
		}
	}
}