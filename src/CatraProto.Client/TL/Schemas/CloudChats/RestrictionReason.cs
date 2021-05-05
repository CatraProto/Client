using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class RestrictionReason : RestrictionReasonBase
	{


        public static int ConstructorId { get; } = -797791052;
		public override string Platform { get; set; }
		public override string Reason { get; set; }
		public override string Text { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Platform);
			writer.Write(Reason);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Platform = reader.Read<string>();
			Reason = reader.Read<string>();
			Text = reader.Read<string>();

		}
	}
}