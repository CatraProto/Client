using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SaveCallDebug : IMethod
	{


        public static int ConstructorId { get; } = 662363518;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Debug { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Debug);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
			Debug = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();

		}
	}
}