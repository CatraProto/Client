using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Report : IMethod<bool>
	{


        public static int ConstructorId { get; } = -1115507112;

		public InputPeerBase Peer { get; set; }
		public IList<int> Id { get; set; }
		public ReportReasonBase Reason { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(Reason);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Id = reader.ReadVector<int>();
			Reason = reader.Read<ReportReasonBase>();

		}
	}
}