using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetParticipant : IMethod
	{
		public static int ConstructorId { get; } = 1416484774;
		public InputChannelBase Channel { get; set; }
		public InputUserBase UserId { get; set; }

		public Type Type { get; init; } = typeof(ChannelParticipantBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
			writer.Write(UserId);
		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			UserId = reader.Read<InputUserBase>();
		}
	}
}