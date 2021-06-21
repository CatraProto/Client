using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockSubheader : PageBlockBase
	{


        public static int ConstructorId { get; } = -248793375;
		public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();

		}
	}
}