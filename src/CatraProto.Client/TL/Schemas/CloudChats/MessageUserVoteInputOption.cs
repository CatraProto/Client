using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageUserVoteInputOption : MessageUserVoteBase
	{
		public static int ConstructorId { get; } = 909603888;
		public override int UserId { get; set; }
		public override int Date { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(UserId);
			writer.Write(Date);
		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Date = reader.Read<int>();
		}
	}
}