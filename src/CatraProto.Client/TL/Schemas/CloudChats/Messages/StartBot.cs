using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class StartBot : IMethod
	{


        public static int ConstructorId { get; } = -421563528;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StartBot);
		public bool IsVector { get; init; } = false;
		public InputUserBase Bot { get; set; }
		public InputPeerBase Peer { get; set; }
		public long RandomId { get; set; }
		public string StartParam { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Bot);
			writer.Write(Peer);
			writer.Write(RandomId);
			writer.Write(StartParam);

		}

		public void Deserialize(Reader reader)
		{
			Bot = reader.Read<InputUserBase>();
			Peer = reader.Read<InputPeerBase>();
			RandomId = reader.Read<long>();
			StartParam = reader.Read<string>();

		}
	}
}