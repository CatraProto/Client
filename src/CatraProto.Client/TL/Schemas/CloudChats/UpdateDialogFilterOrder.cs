using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateDialogFilterOrder : UpdateBase
	{
		public static int ConstructorId { get; } = -1512627963;
		public IList<int> Order { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Order);
		}

		public override void Deserialize(Reader reader)
		{
			Order = reader.ReadVector<int>();
		}
	}
}