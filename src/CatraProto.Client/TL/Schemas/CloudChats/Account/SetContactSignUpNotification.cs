using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetContactSignUpNotification : IMethod
	{


        public static int ConstructorId { get; } = -806076575;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.SetContactSignUpNotification);
		public bool IsVector { get; init; } = false;
		public bool Silent { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Silent);

		}

		public void Deserialize(Reader reader)
		{
			Silent = reader.Read<bool>();

		}
	}
}