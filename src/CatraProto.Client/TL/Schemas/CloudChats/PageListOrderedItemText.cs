using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageListOrderedItemText : PageListOrderedItemBase
	{


        public static int ConstructorId { get; } = 1577484359;
		public override string Num { get; set; }
		public RichTextBase Text { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Num);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Num = reader.Read<string>();
			Text = reader.Read<RichTextBase>();

		}
	}
}