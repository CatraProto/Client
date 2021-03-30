using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCodeTypeApp : SentCodeTypeBase
	{


        public static int ConstructorId { get; } = 1035688326;
		public int Length { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Length);

		}

		public override void Deserialize(Reader reader)
		{
			Length = reader.Read<int>();

		}
	}
}