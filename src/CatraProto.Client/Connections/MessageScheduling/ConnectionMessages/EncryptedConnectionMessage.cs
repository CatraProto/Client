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

using System;
using System.Buffers;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Auth.AuthKey;
using CatraProto.TL;

namespace CatraProto.Client.Connections.MessageScheduling.ConnectionMessages
{
    internal struct EncryptedConnectionMessage : IConnectionMessage
    {
        public long Length
        {
            get => Body.Length;
        }

        // Default initialization is explicit because this is a struct and we can't use Import if fields are not initialized first
        public AuthKeyObject AuthKey { get; init; }
        public long AuthKeyId { get; private set; } = 0;
        public long MessageId { get; private set; } = 0;
        public MemoryStream Body { get; private set; }
        public byte[]? MsgKey { get; private set; } = null;
        public long Salt { get; private set; } = 0;
        public long SessionId { get; private set; } = 0;
        public int SeqNo { get; private set; } = 0;
        public byte[]? Padding { get; private set; } = null;

        public EncryptedConnectionMessage(AuthKeyObject authKey, MemoryStream payload, bool fromClient = false)
        {
            // awful hack
            Body = null!;
            AuthKey = authKey;

            Import(payload, fromClient);
        }

        public EncryptedConnectionMessage(AuthKeyObject authKey, long messageId, long salt, long sessionId, int seqNo, MemoryStream body)
        {
            AuthKey = authKey;
            MessageId = messageId;
            Salt = salt;
            SessionId = sessionId;
            SeqNo = seqNo;
            Body = body;
            AuthKeyId = AuthKey.AuthKeyId;
        }

        public void Import(MemoryStream message)
        {
            Import(message, false);
        }

        public void Import(MemoryStream message, bool fromClient)
        {
            using (var reader = new BinaryReader(message, Encoding.Default, true))
            {
                AuthKeyId = reader.ReadInt64();
                MsgKey = reader.ReadBytes(16);
                using var encryptor = AesCryptoCreator.CreateEncryptorV2(AuthKey.KeyArray, MsgKey, fromClient);
                using var decryptedText = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
                encryptor.Decrypt(reader.BaseStream, decryptedText);
                decryptedText.Seek(0, SeekOrigin.Begin);
                using (var cleanReader = new BinaryReader(decryptedText))
                {
                    Salt = cleanReader.ReadInt64();
                    SessionId = cleanReader.ReadInt64();
                    MessageId = cleanReader.ReadInt64();
                    SeqNo = cleanReader.ReadInt32();
                    var length = cleanReader.ReadInt32();

                    var copyBuffer = ArrayPool<byte>.Shared.Rent(length);
                    decryptedText.Read(copyBuffer, 0, length);
                    var messageBody = MemoryHelper.RecyclableMemoryStreamManager.GetStream(copyBuffer.AsSpan(0, length));
                    ArrayPool<byte>.Shared.Return(copyBuffer);

                    Body = messageBody;
                    Padding = cleanReader.ReadBytes((int)(decryptedText.Length - decryptedText.Position));
                }
            }
        }

        public MemoryStream GetPlainTextStream(byte[]? customPadding = null)
        {
            var outputStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            using (var plainWriter = new BinaryWriter(outputStream, Encoding.Default, true))
            {
                Body.Seek(0, SeekOrigin.Begin);
                plainWriter.Write(Salt);
                plainWriter.Write(SessionId);
                plainWriter.Write(MessageId);
                plainWriter.Write(SeqNo);
                plainWriter.Write((int)Body.Length);
                Body.CopyTo(plainWriter.BaseStream);

                if (customPadding != null)
                {
                    plainWriter.Write(customPadding);
                }
                else
                {
                    CryptoTools.AddPadding(plainWriter.BaseStream, 16, 12);
                }
                Body.Seek(0, SeekOrigin.Begin);
            }

            outputStream.Seek(0, SeekOrigin.Begin);
            return outputStream;
        }

        public byte[] ComputeMsgKey(MemoryStream plainText, bool fromClient)
        {
            var x = fromClient ? 0 : 8;
            using var sha256 = SHA256.Create();
            using var toHashStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            toHashStream.Write(AuthKey.KeyArray, 88 + x, 32);
            plainText.CopyTo(toHashStream);
            toHashStream.Seek(0, SeekOrigin.Begin);
            return sha256.ComputeHash(toHashStream).Skip(8).Take(16).ToArray();
        }

        public MemoryStream Export()
        {
            var outputStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            using (var writer = new BinaryWriter(outputStream, Encoding.Default, true))
            {
                using var plainStream = GetPlainTextStream();
                var msgKey = ComputeMsgKey(plainStream, true);
                plainStream.Seek(0, SeekOrigin.Begin);

                using var encryptor = AesCryptoCreator.CreateEncryptorV2(AuthKey.KeyArray, msgKey, true);
                writer.Write(AuthKeyId);
                writer.Write(msgKey);
                encryptor.Encrypt(plainStream, writer.BaseStream);
            }

            outputStream.Seek(0, SeekOrigin.Begin);
            return outputStream;
        }

        public void Dispose()
        {
            Body.Dispose();
        }
    }
}