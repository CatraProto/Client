using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSetMultiCovered : StickerSetCoveredBase
	{


        public static int ConstructorId { get; } = 872932635;
		public override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Covers { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Set);
			writer.Write(Covers);

		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
			Covers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}