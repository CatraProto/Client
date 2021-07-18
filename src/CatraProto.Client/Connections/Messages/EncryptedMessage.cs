using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using CatraProto.Client.Connections.Messages.Interfaces;
using CatraProto.Client.Crypto;
using CatraProto.Client.Crypto.Aes;
using CatraProto.Client.Extensions;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.TL;

namespace CatraProto.Client.Connections.Messages
{
    sealed class EncryptedMessage : IMessage
    {
        public int Length
        {
            get => Body.Length;
        }

        private AuthKey _authKey;
        public byte[] MsgKey { get; private set; }
        public long Salt { get; set; }
        public long SessionId { get; set; }
        public int SeqNo { get; set; }
        public long AuthKeyId { get; set; }
        public long MessageId { get; set; }
        public byte[] Body { get; set; }

        public EncryptedMessage()
        {
            
        }
        
        public EncryptedMessage(AuthKey authKey)
        {
            _authKey = authKey;
        }

        public EncryptedMessage(AuthKey authKey, byte[] message) : this(authKey)
        {
            Import(message);
        }

        public void Import(byte[] message)
        {
            using (var reader = new BinaryReader(message.ToMemoryStream()))
            {
                AuthKeyId = reader.ReadInt64();
                MsgKey = reader.ReadBytes(16);
                using var encryptor = _authKey.CreateEncryptor(MsgKey, false);
                var encryptedBuffer = reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position));
                var decryptedText = encryptor.Decrypt(encryptedBuffer);
                using (var cleanReader = new BinaryReader(decryptedText.ToMemoryStream()))
                {
                    Salt = cleanReader.ReadInt64();
                    SessionId = cleanReader.ReadInt64();
                    MessageId = cleanReader.ReadInt64();
                    SeqNo = cleanReader.ReadInt32();
                    var length = cleanReader.ReadInt32();
                    Body = cleanReader.ReadBytes(length);
                }
            }
        }

        public byte[] Export()
        {
            using (var writer = new BinaryWriter(new MemoryStream()))
            {
                using (var encryptedDataWriter = new BinaryWriter(new MemoryStream()))
                {
                    encryptedDataWriter.Write(Salt);
                    encryptedDataWriter.Write(SessionId);
                    encryptedDataWriter.Write(MessageId);
                    encryptedDataWriter.Write(SeqNo);
                    encryptedDataWriter.Write(Body.Length);
                    encryptedDataWriter.Write(Body);
                    encryptedDataWriter.Write(CryptoTools.GenerateRandomBytes(12));
                    encryptedDataWriter.Write(CryptoTools.GenerateRandomBytes(16 - (int)encryptedDataWriter.BaseStream.Length % 16));
                    
                    var toEncryptData = ((MemoryStream)encryptedDataWriter.BaseStream).ToArray();
                    var msgKey = SHA256.HashData(_authKey.RawAuthKey.Skip(88).Take(32).Concat(toEncryptData).ToArray()).Skip(8).Take(16).ToArray();
                    using var encryptor = _authKey.CreateEncryptor(msgKey, true);
                    
                    writer.Write(AuthKeyId);
                    writer.Write(msgKey);
                    writer.Write(encryptor.Encrypt(toEncryptData));
                }
                return ((MemoryStream)writer.BaseStream).ToArray();
            }
        }
    }
}