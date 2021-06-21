using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDeleteChannelMessages : UpdateBase
	{
		public static int ConstructorId { get; } = -1015733815;
		public int ChannelId { get; set; }
		public IList<int> Messages { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(Messages);
			writer.Write(Pts);
			writer.Write(PtsCount);
		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			Messages = reader.ReadVector<int>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
		}
	}
}