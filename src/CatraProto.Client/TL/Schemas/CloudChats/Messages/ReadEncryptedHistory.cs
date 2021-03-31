using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ReadEncryptedHistory : IMethod<bool>
	{


        public static int ConstructorId { get; } = 2135648522;

		public InputEncryptedChatBase Peer { get; set; }
		public int MaxDate { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MaxDate);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputEncryptedChatBase>();
			MaxDate = reader.Read<int>();

		}
	}
}