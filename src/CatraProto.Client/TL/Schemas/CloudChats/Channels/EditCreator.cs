using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class EditCreator : IMethod
	{
		public static int ConstructorId { get; } = -1892102881;
		public InputChannelBase Channel { get; set; }
		public InputUserBase UserId { get; set; }
		public InputCheckPasswordSRPBase Password { get; set; }

		public Type Type { get; init; } = typeof(UpdatesBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Channel);
			writer.Write(UserId);
			writer.Write(Password);
		}

		public void Deserialize(Reader reader)
		{
			Channel = reader.Read<InputChannelBase>();
			UserId = reader.Read<InputUserBase>();
			Password = reader.Read<InputCheckPasswordSRPBase>();
		}
	}
}