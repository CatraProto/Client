using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockSlideshow : PageBlockBase
	{


        public static int ConstructorId { get; } = 52401552;
		public IList<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase> Items { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Items);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Items = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();

		}
	}
}