using CatraProto.Client.MTProto.Messages.Interfaces;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Messages
{
	class IncomingMessage : IMessage
	{
		public bool IsEncrypted { get; set; }
		public IObject Body { get; set; }
	}
}