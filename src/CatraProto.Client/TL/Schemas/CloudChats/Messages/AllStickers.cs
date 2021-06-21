using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AllStickers : AllStickersBase
	{


        public static int ConstructorId { get; } = -302170017;
		public int Hash { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase> Sets { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Sets);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Sets = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();

		}
	}
}