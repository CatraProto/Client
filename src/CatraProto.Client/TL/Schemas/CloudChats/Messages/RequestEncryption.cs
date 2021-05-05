using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class RequestEncryption : IMethod<EncryptedChatBase>
	{


        public static int ConstructorId { get; } = -162681021;

		public Type Type { get; init; } = typeof(RequestEncryption);
		public bool IsVector { get; init; } = false;
		public InputUserBase UserId { get; set; }
		public int RandomId { get; set; }
		public byte[] GA { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(RandomId);
			writer.Write(GA);

		}

		public void Deserialize(Reader reader)
		{
			UserId = reader.Read<InputUserBase>();
			RandomId = reader.Read<int>();
			GA = reader.Read<byte[]>();

		}
	}
}