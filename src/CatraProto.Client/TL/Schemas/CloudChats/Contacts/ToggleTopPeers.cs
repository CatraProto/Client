using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ToggleTopPeers : IMethod
	{


        public static int ConstructorId { get; } = -2062238246;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Contacts.ToggleTopPeers);
		public bool IsVector { get; init; } = false;
		public bool Enabled { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Enabled);

		}

		public void Deserialize(Reader reader)
		{
			Enabled = reader.Read<bool>();

		}
	}
}