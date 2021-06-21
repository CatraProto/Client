using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class InviteToChannel : IMethod
	{
		public static int ConstructorId { get; } = 429865580;
		public InputChannelBase Channel { get; set; }
		public IList<InputUserBase> Users { get; set; }

		public Type Type { get; init; } = typeof(UpdatesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(Users);
		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			Users = reader.ReadVector<InputUserBase>();
		}
	}
}