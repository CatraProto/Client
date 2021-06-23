using System.IO;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.Extensions;

namespace CatraProto.Client.Connections.Messages
{
	//Unencrypted Message
	// | int64 auth_key_id = 0 | int64 message_id | int32 message_data_length | bytes message_data |
	sealed class UnencryptedMessage : IMessage
	{
		public UnencryptedMessage()
		{
		}

		public UnencryptedMessage(byte[] message)
		{
			Import(message);
		}

		public long AuthKeyId { get; set; }
		public long MessageId { get; set; }
		public byte[] Body { get; set; }

		public void Import(byte[] message)
		{
			using (var reader = new BinaryReader(message.ToMemoryStream()))
			{
				AuthKeyId = reader.ReadInt64();
				MessageId = reader.ReadInt64();
				var length = reader.ReadInt32();
				Body = reader.ReadBytes(length);
			}
		}

		public byte[] Export()
		{
			using (var writer = new BinaryWriter(new MemoryStream()))
			{
				writer.Write(AuthKeyId);
				writer.Write(MessageId);
				writer.Write(Body.Length);
				writer.Write(Body);
				return ((MemoryStream)writer.BaseStream).ToArray();
			}
		}
	}
}