using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PollAnswer : PollAnswerBase
	{


        public static int ConstructorId { get; } = 1823064809;
		public override string Text { get; set; }
		public override byte[] Option { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Text);
			writer.Write(Option);

		}

		public override void Deserialize(Reader reader)
		{
			Text = reader.Read<string>();
			Option = reader.Read<byte[]>();

		}
	}
}