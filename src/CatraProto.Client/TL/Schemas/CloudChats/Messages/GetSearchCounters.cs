using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetSearchCounters : IMethod
	{
		public static int ConstructorId { get; } = 1932455680;
		public InputPeerBase Peer { get; set; }
		public IList<MessagesFilterBase> Filters { get; set; }

		public Type Type { get; init; } = typeof(SearchCounterBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(Filters);
		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputPeerBase>();
			Filters = reader.ReadVector<MessagesFilterBase>();
		}
	}
}