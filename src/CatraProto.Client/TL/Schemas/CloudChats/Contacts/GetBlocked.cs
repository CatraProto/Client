using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class GetBlocked : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedBase>
	{


        public static int ConstructorId { get; } = -176409329;

		public int Offset { get; set; }
		public int Limit { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Offset);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}