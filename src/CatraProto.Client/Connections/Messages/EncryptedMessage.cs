using System;
using System.IO;
using System.Numerics;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.Crypto.Aes;
using CatraProto.Client.Extensions;

namespace CatraProto.Client.Connections.Messages
{
    sealed class EncryptedMessage : IMessage
    {
        public int Length
        {
            get => Body.Length;
        }

        public BigInteger MsgKey { get; set; }
        public long Salt { get; set; }
        public long SessionId { get; set; }
        public int SeqNo { get; set; }
        public long AuthKeyId { get; set; }
        public long MessageId { get; set; }
        public byte[] Body { get; set; }
        private IgeEncryptor _encryptor;

        public EncryptedMessage(IgeEncryptor encryptor)
        {
            _encryptor = encryptor;
        }

        public EncryptedMessage(IgeEncryptor encryptor, byte[] message)
        {
            _encryptor = encryptor;
            Import(message);
        }

        public void Import(byte[] message)
        {
            using (var reader = new BinaryReader(message.ToMemoryStream()))
            {
                AuthKeyId = reader.ReadInt64();
                MsgKey = new BigInteger(reader.ReadBytes(128));
                var encryptedBuffer = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
                var decryptedText = _encryptor.Decrypt(encryptedBuffer);
                using (var cleanReader = new BinaryReader(decryptedText.ToMemoryStream()))
                {
                    Salt = cleanReader.ReadInt64();
                    SessionId = cleanReader.ReadInt64();
                    MessageId = cleanReader.ReadInt64();
                    SeqNo = cleanReader.ReadInt32();
                    var length = cleanReader.ReadInt32();
                }
            }
        }

        public byte[] Export()
        {
            throw new NotImplementedException();
        }
    }
}