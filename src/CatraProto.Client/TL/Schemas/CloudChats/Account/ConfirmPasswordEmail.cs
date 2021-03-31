using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ConfirmPasswordEmail : IMethod<bool>
	{


        public static int ConstructorId { get; } = -1881204448;

		public string Code { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Code);

		}

		public void Deserialize(Reader reader)
		{
			Code = reader.Read<string>();

		}
	}
}