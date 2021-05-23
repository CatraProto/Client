using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListItemBlocks : PageListItemBase
	{


        public static int ConstructorId { get; } = 635466748;
		public IList<PageBlockBase> Blocks { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Blocks);

		}

		public override void Deserialize(Reader reader)
		{
			Blocks = reader.ReadVector<PageBlockBase>();

		}
	}
}