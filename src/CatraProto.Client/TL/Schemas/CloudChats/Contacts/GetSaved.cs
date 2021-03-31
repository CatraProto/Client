using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class GetSaved : IMethod<CatraProto.Client.TL.Schemas.CloudChats.SavedContactBase>
	{


        public static int ConstructorId { get; } = -2098076769;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{

		}
	}
}