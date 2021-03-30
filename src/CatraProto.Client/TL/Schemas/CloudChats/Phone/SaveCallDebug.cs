using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SaveCallDebug : IMethod<bool>
	{


        public static int ConstructorId { get; } = 662363518;

		public InputPhoneCallBase Peer { get; set; }
		public DataJSONBase Debug { get; set; }

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
			Peer = reader.Read<InputPhoneCallBase>();
			Debug = reader.Read<DataJSONBase>();

		}
	}
}