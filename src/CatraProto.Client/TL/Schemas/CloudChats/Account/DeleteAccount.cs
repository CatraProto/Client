using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class DeleteAccount : IMethod
	{


        public static int ConstructorId { get; } = 1099779595;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public string Reason { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Reason);

		}

		public void Deserialize(Reader reader)
		{
			Reason = reader.Read<string>();

		}
	}
}