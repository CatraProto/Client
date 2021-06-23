using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CatraProto.Client.Connections
{
    class NetworkStreamTools
    {
        public static async Task<byte[]> ReadBytes(int lenght, int offset, NetworkStream stream)
        {
            var buffer = new byte[lenght];
            await stream.ReadAsync(buffer.AsMemory(offset, lenght));
            return buffer;
        }
    }
}