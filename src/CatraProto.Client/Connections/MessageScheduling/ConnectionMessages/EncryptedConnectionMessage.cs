/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Buffers;
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

                var decryptedText = ArrayPool<byte>.Shared.Rent(encryptedBuffer.Length);
                encryptor.Decrypt(encryptedBuffer, decryptedText);
                using (var cleanReader = new BinaryReader(decryptedText.ToMemoryStream()))
                {
                    Salt = cleanReader.ReadInt64();
                    SessionId = cleanReader.ReadInt64();
                    MessageId = cleanReader.ReadInt64();
                    SeqNo = cleanReader.ReadInt32();
                    var length = cleanReader.ReadInt32();
                    Body = cleanReader.ReadBytes(length);
                    // ArrayPool might have returned an array bigger than what we requested so cleanReader.BaseStream.Length return a number bigger than the actual payload's length
                    Padding = cleanReader.ReadBytes((int)(encryptedBuffer.Length - cleanReader.BaseStream.Position));
                }
                ArrayPool<byte>.Shared.Return(decryptedText, true);
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

                var encrypted = ArrayPool<byte>.Shared.Rent(toEncryptData.Length);
                encryptor.Encrypt(toEncryptData, encrypted);

                // ArrayPool might have returned an array bigger than what we requested and writing more than we have encrypted would invalidate the payload
                writer.Write(encrypted, 0, toEncryptData.Length);
                ArrayPool<byte>.Shared.Return(encrypted, true);
                
                var array = ((MemoryStream)writer.BaseStream).ToArray();
                return array;
            }
        }
    }
}