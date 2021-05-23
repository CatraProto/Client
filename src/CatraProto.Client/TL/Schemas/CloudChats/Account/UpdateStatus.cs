using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class UpdateStatus : IMethod
	{


        public static int ConstructorId { get; } = 1713919532;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.UpdateStatus);
		public bool IsVector { get; init; } = false;
		public bool Offline { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Offline);

		}

		public void Deserialize(Reader reader)
		{
			Offline = reader.Read<bool>();

		}
	}
}