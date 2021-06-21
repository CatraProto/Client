using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockPullquote : PageBlockBase
	{


        public static int ConstructorId { get; } = 1329878739;
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Caption { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();

		}
	}
}