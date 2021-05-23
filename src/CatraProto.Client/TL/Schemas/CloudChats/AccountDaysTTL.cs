using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class AccountDaysTTL : AccountDaysTTLBase
	{


        public static int ConstructorId { get; } = -1194283041;
		public override int Days { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Days);

		}

		public override void Deserialize(Reader reader)
		{
			Days = reader.Read<int>();

		}
	}
}