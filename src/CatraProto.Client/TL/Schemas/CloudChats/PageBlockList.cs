using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockList : PageBlockBase
	{


        public static int ConstructorId { get; } = -454524911;
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase> Items { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Items);

		}

		public override void Deserialize(Reader reader)
		{
			Items = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageListItemBase>();

		}
	}
}