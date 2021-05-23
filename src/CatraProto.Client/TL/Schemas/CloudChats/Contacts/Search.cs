using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class Search : IMethod
	{


        public static int ConstructorId { get; } = 301470424;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Contacts.Search);
		public bool IsVector { get; init; } = false;
		public string Q { get; set; }
		public int Limit { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Q);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Q = reader.Read<string>();
			Limit = reader.Read<int>();

		}
	}
}