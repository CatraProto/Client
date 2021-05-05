using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SendSignalingData : IMethod<bool>
	{


        public static int ConstructorId { get; } = -8744061;

		public Type Type { get; init; } = typeof(SendSignalingData);
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