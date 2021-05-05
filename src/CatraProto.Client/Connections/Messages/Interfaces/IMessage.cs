using System.IO;
using System.Threading;
using CatraProto.Client.Extensions;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Connections.Messages.Interfaces
{
    interface IMessage
    {
        public long AuthKeyId { get; set; }
        public long MessageId { get; set; }
        public byte[] Body { get; set; }
        public CancellationToken Token { get; set; }

        public void Import(byte[] message);
        public byte[] Export();
    }
}