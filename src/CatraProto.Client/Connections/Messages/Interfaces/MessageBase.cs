using System;
using System.IO;
using CatraProto.Extensions;

namespace CatraProto.Client.Connections.Messages.Interfaces
{
    abstract class MessageBase : IDisposable
    {
        public long AuthKeyId { get; set; }
        public long MessageId { get; set; }
        public MemoryStream Message { get; set; }
        protected bool Disposed { get; set; } = false;
        public int Length
        {
            get
            {
                CheckDisposed();
                return (int)Message.Length;
            }
        }

        public abstract void Deserialize(byte[] message);
        public abstract byte[] Serialize();
        
        public static bool IsMessageEncrypted(byte[] message)
        {
            using var stream = message.ToMemoryStream();
            using var binaryReader = new BinaryReader(stream);
            return binaryReader.ReadInt64() != 0;
        }

        protected void CheckDisposed()
        {
            if (Disposed)
            {
                throw new ObjectDisposedException("This object has been disposed and can't be used anymore.");
            }
        }
        
        public virtual void Dispose()
        {
            Disposed = true;
            Message?.Dispose();
        }
    }
}
