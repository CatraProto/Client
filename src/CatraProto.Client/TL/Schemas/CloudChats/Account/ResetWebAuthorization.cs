using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ResetWebAuthorization : IMethod<bool>
	{


        public static int ConstructorId { get; } = 755087855;

		public long Hash { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<long>();

		}
	}
}