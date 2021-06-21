using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageTableRow : PageTableRowBase
	{
		public static int ConstructorId { get; } = -524237339;
		public override IList<PageTableCellBase> Cells { get; set; }

		public override void UpdateFlags()
		{
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Cells);
		}

		public override void Deserialize(Reader reader)
		{
			Cells = reader.ReadVector<PageTableCellBase>();
		}
	}
}