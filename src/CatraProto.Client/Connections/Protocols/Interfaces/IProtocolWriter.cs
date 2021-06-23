using System.Threading;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections.Protocols.Interfaces
{
	interface IProtocolWriter
	{
		public Task SendAsync(byte[] message, CancellationToken token = default);
	}
}