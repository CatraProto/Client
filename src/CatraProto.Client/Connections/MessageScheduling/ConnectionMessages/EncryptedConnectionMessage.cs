using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.TL;

namespace CatraProto.Client.Connections.MessageScheduling.ConnectionMessages
{
    internal sealed class EncryptedConnectionMessage : IConnectionMessage
    {
        public int Length
        {
            get => Body.Length;
        }

        public AuthKeyObject AuthKey { get; init; }
        public long AuthKeyId { get; private set; }
        public long MessageId { get; private set; }
        public byte[] Body { get; private set; }
        public byte[]? MsgKey { get; private set; }
        public long Salt { get; private set; }
        public long SessionId { get; private set; }
        public int SeqNo { get; private set; }
        public byte[]? Padding { get; private set; } = null;

        public EncryptedConnectionMessage(AuthKeyObject authKey, byte[] payload, bool fromClient = false)
        {
            Body = null!;
            AuthKey = authKey;
            Import(payload, fromClient);
        }

        public EncryptedConnectionMessage(AuthKeyObject authKey, long messageId, long salt, long sessionId, int seqNo, byte[] body)
        {
            AuthKey = authKey;
            MessageId = messageId;
            Salt = salt;
            SessionId = sessionId;
            SeqNo = seqNo;
            Body = body;
            AuthKeyId = AuthKey.AuthKeyId;
        }

        public void Import(byte[] message)
        {
            Import(message, false);
        }

        public void Import(byte[] message, bool fromClient)
        {
            using (var reader = new BinaryReader(message.ToMemoryStream()))
            {
                AuthKeyId = reader.ReadInt64();
                MsgKey = reader.ReadBytes(16);
                using var encryptor = AesCryptoCreator.CreateEncryptorV2(AuthKey.KeyArray, MsgKey, fromClient);
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
                    Padding = cleanReader.ReadBytes((int)(cleanReader.BaseStream.Length - cleanReader.BaseStream.Position));
                }
            }
        }

        public MemoryStream GetPlainTextStream(byte[]? customPadding = null)
        {
            using (var plainWriter = new BinaryWriter(new MemoryStream(), Encoding.Default, true))
            {
                plainWriter.Write(Salt);
                plainWriter.Write(SessionId);
                plainWriter.Write(MessageId);
                plainWriter.Write(SeqNo);
                plainWriter.Write(Body.Length);
                plainWriter.Write(Body);

                if (customPadding != null)
                {
                    plainWriter.Write(customPadding);
                }
                else
                {
                    CryptoTools.AddPadding(plainWriter.BaseStream, 16, 12);
                }

                return (MemoryStream)plainWriter.BaseStream;
            }
        }

        public byte[] ComputeMsgKey(byte[] plainText, bool fromClient)
        {
            var x = fromClient ? 0 : 8;
            return SHA256.HashData(AuthKey.KeyArray.Skip(88 + x).Take(32).Concat(plainText).ToArray()).Skip(8).Take(16).ToArray();
        }

        public byte[] Export()
        {
            using (var writer = new BinaryWriter(new MemoryStream()))
            {
                using var plainStream = GetPlainTextStream();
                var toEncryptData = plainStream.ToArray();
                var msgKey = ComputeMsgKey(toEncryptData, true);

                using var encryptor = AesCryptoCreator.CreateEncryptorV2(AuthKey.KeyArray, msgKey, true);
                writer.Write(AuthKeyId);
                writer.Write(msgKey);
                writer.Write(encryptor.Encrypt(toEncryptData));

                var array = ((MemoryStream)writer.BaseStream).ToArray();
                return array;
            }
        }
    }
}