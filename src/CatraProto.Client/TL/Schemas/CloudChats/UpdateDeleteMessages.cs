using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDeleteMessages : UpdateBase
	{
		public static int ConstructorId { get; } = -1576161051;
		public IList<int> Messages { get; set; }
		public int Pts { get; set; }
		public int PtsCount { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Messages);
			writer.Write(Pts);
			writer.Write(PtsCount);
		}

		public override void Deserialize(Reader reader)
		{
			Messages = reader.ReadVector<int>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
		}
	}
}