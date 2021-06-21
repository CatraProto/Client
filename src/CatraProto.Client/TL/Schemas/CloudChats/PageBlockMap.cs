using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockMap : PageBlockBase
	{


        public static int ConstructorId { get; } = -1538310410;
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }
		public int Zoom { get; set; }
		public int W { get; set; }
		public int H { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Geo);
			writer.Write(Zoom);
			writer.Write(W);
			writer.Write(H);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			Zoom = reader.Read<int>();
			W = reader.Read<int>();
			H = reader.Read<int>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();

		}
	}
}