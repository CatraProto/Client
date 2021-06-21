using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetFullChannel : IMethod
	{
		public static int ConstructorId { get; } = 141781513;
		public InputChannelBase Channel { get; set; }

		public Type Type { get; init; } = typeof(Messages.ChatFullBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Channel);
		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
		}
	}
}