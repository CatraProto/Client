using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageTableRow : PageTableRowBase
	{


        public static int ConstructorId { get; } = -524237339;
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> Cells { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Cells);

		}

		public override void Deserialize(Reader reader)
		{
			Cells = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase>();

		}
	}
}