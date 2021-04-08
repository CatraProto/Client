using System;
using System.IO;
using System.Threading;
using CatraProto.Client.Extensions;

namespace CatraProto.Client.Connections.Messages.Interfaces
{
    abstract class MessageBase
    {
        public long AuthKeyId { get; set; }
        public long MessageId { get; set; }
        public byte[] Message { get; set; }
        public int Length => Message.Length;

        public abstract void Deserialize(byte[] message);
        public abstract byte[] Serialize();
        
        public static bool IsMessageEncrypted(byte[] message)
        {
            using var stream = message.ToMemoryStream();
            using var binaryReader = new BinaryReader(stream);
            return binaryReader.ReadInt64() != 0;
        }
    }
}
