using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SendSignalingData : IMethod
	{


        public static int ConstructorId { get; } = -8744061;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Phone.SendSignalingData);
		public bool IsVector { get; init; } = false;
		public InputPhoneCallBase Peer { get; set; }
		public byte[] Data { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Data);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPhoneCallBase>();
			Data = reader.Read<byte[]>();

		}
	}
}