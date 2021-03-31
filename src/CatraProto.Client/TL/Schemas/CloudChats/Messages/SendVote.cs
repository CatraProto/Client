using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendVote : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{


        public static int ConstructorId { get; } = 283795844;

		public InputPeerBase Peer { get; set; }
		public int MsgId { get; set; }
		public IList<byte[]> Options { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(MsgId);
			writer.Write(Options);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			MsgId = reader.Read<int>();
			Options = reader.ReadVector<byte[]>();

		}
	}
}