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

using System.IO;
using System.Text;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.Client.Crypto;
using CatraProto.TL;

namespace CatraProto.Client.Connections.MessageScheduling.ConnectionMessages
{
    internal struct UnencryptedConnectionMessage : IConnectionMessage
    {
        public long AuthKeyId
        {
            get => 0;
        }

        public long MessageId { get; private set; }
        public MemoryStream Body { get; private set; }

        public UnencryptedConnectionMessage(long messageId, MemoryStream body)
        {
            MessageId = messageId;
            Body = body;
        }

        public UnencryptedConnectionMessage(MemoryStream payload)
        {
            Body = null!;
            if (payload.Length == 4)
            {
                MessageId = 0;
                Body = payload;
            }
            else
            {
                MessageId = 0;
                Import(payload);
            }
        }

        public void Import(MemoryStream message)
        {
            using (var reader = new BinaryReader(message, Encoding.Default, true))
            {
                reader.BaseStream.Seek(8, SeekOrigin.Current);
                MessageId = reader.ReadInt64();
                var length = reader.ReadInt32();

                var bodyStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
                reader.BaseStream.CopyTo(bodyStream);
                bodyStream.Seek(0, SeekOrigin.Begin);
                Body = bodyStream;
            }
        }

        public MemoryStream Export()
        {
            var outputStream = MemoryHelper.RecyclableMemoryStreamManager.GetStream();
            using (var writer = new BinaryWriter(outputStream, Encoding.Default, true))
            {
                writer.Write(AuthKeyId);
                writer.Write(MessageId);
                writer.Write((int)Body.Length);
                Body.CopyTo(outputStream);
                Body.Seek(0, SeekOrigin.Begin);
            }

            outputStream.Seek(offset: 0, SeekOrigin.Begin);
            return outputStream;
        }

        public void Dispose()
        {
            Body.Dispose();
        }
    }
}