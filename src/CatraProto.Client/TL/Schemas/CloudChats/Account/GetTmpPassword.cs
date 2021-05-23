using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetTmpPassword : IMethod
	{


        public static int ConstructorId { get; } = 1151208273;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.GetTmpPassword);
		public bool IsVector { get; init; } = false;
		public InputCheckPasswordSRPBase Password { get; set; }
		public int Period { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Password);
			writer.Write(Period);

		}

		public void Deserialize(Reader reader)
		{
			Password = reader.Read<InputCheckPasswordSRPBase>();
			Period = reader.Read<int>();

		}
	}
}