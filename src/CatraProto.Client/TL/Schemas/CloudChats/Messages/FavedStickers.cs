using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FavedStickers : FavedStickersBase
	{


        public static int ConstructorId { get; } = -209768682;
		public int Hash { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Stickers { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Packs);
			writer.Write(Stickers);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Packs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>();
			Stickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}