using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSetCovered : StickerSetCoveredBase
	{


        public static int ConstructorId { get; } = 1678812626;
		public override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Cover { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Set);
			writer.Write(Cover);

		}

		public override void Deserialize(Reader reader)
		{
			Set = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
			Cover = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}