using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class GetStatuses : IMethod<CatraProto.Client.TL.Schemas.CloudChats.ContactStatusBase>
	{


        public static int ConstructorId { get; } = -995929106;


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