using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecurePlainPhone : SecurePlainDataBase
	{


        public static int ConstructorId { get; } = 2103482845;
		public string Phone { get; set; }

		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Phone);

		}

		public override void Deserialize(Reader reader)
		{
			Phone = reader.Read<string>();

		}
	}
}