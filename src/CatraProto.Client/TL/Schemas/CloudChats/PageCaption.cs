using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageCaption : PageCaptionBase
	{


        public static int ConstructorId { get; } = 1869903447;
		public override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }
		public override CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Credit { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Credit);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Credit = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();

		}
	}
}