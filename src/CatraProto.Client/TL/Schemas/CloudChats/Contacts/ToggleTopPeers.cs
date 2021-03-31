using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ToggleTopPeers : IMethod<bool>
	{


        public static int ConstructorId { get; } = -2062238246;

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