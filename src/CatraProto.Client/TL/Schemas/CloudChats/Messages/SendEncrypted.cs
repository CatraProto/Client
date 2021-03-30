using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendEncrypted : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Messages.SentEncryptedMessageBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 0
		}

        public static int ConstructorId { get; } = 1157265941;

		public int Flags { get; set; }
		public bool Silent { get; set; }
		public InputEncryptedChatBase Peer { get; set; }
		public long RandomId { get; set; }
		public byte[] Data { get; set; }

		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(RandomId);
			writer.Write(Data);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputEncryptedChatBase>();
			RandomId = reader.Read<long>();
			Data = reader.Read<byte[]>();

		}
	}
}