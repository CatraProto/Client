using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetUnreadMentions : IMethod
	{


        public static int ConstructorId { get; } = 1180140658;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.GetUnreadMentions);
		public bool IsVector { get; init; } = false;
		public InputPeerBase Peer { get; set; }
		public int OffsetId { get; set; }
		public int AddOffset { get; set; }
		public int Limit { get; set; }
		public int MaxId { get; set; }
		public int MinId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(OffsetId);
			writer.Write(AddOffset);
			writer.Write(Limit);
			writer.Write(MaxId);
			writer.Write(MinId);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			OffsetId = reader.Read<int>();
			AddOffset = reader.Read<int>();
			Limit = reader.Read<int>();
			MaxId = reader.Read<int>();
			MinId = reader.Read<int>();

		}
	}
}