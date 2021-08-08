using System.IO;
using System.Linq;
using System.Security.Cryptography;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.Crypto;
using CatraProto.Client.Extensions;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;

namespace CatraProto.Client.Connections.MessageScheduling.ConnectionMessages
{
    sealed class EncryptedConnectionMessage : IConnectionMessage
    {
        public int Length
        {
            get => Body.Length;
        }

        public AuthKey AuthKey { get; init; }
        public long AuthKeyId { get; private set; }
        public long MessageId { get; private set; }
        public byte[] Body { get; private set; }
        public byte[]? MsgKey { get; private set; }
        public long Salt { get; private set; }
        public long SessionId { get; private set; }
        public int SeqNo { get; private set; }

        public EncryptedConnectionMessage(AuthKey authKey, byte[] payload)
        {
            Body = null!;
            AuthKey = authKey;
            Import(payload);
        }

        public EncryptedConnectionMessage(AuthKey authKey, long messageId, long salt, long sessionId, int seqNo, byte[] body)
        {
            AuthKey = authKey;
            MessageId = messageId;
            Salt = salt;
            SessionId = sessionId;
            SeqNo = seqNo;
            Body = body;
            AuthKeyId = AuthKey.AuthKeyId!.Value;
        }

        public void Import(byte[] message)
        {
            using (var reader = new BinaryReader(message.ToMemoryStream()))
            {
                AuthKeyId = reader.ReadInt64();
                MsgKey = reader.ReadBytes(16);
                using var encryptor = AuthKey.CreateEncryptorV2(MsgKey, false);
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
                using (var plainWriter = new BinaryWriter(new MemoryStream()))
                {
                    plainWriter.Write(Salt);
                    plainWriter.Write(SessionId);
                    plainWriter.Write(MessageId);
                    plainWriter.Write(SeqNo);
                    plainWriter.Write(Body.Length);
                    plainWriter.Write(Body);

                    CryptoTools.AddPadding(plainWriter.BaseStream, 16, 12);

                    var toEncryptData = ((MemoryStream)plainWriter.BaseStream).ToArray();
                    var msgKey = SHA256.HashData(AuthKey.RawAuthKey!.Skip(88).Take(32).Concat(toEncryptData).ToArray()).Skip(8).Take(16).ToArray();
                    using var encryptor = AuthKey.CreateEncryptorV2(msgKey, true);

                    writer.Write(AuthKeyId);
                    writer.Write(msgKey);
                    writer.Write(encryptor.Encrypt(toEncryptData));
                }

                return ((MemoryStream)writer.BaseStream).ToArray();
            }
        }
    }
}