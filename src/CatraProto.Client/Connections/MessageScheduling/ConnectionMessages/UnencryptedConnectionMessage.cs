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
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.Connections.MessageScheduling.ConnectionMessages
{
    internal sealed class UnencryptedConnectionMessage : IConnectionMessage
    {
        public long AuthKeyId
        {
            get => 0;
        }

        public long MessageId { get; private set; }
        public byte[] Body { get; private set; }

        public UnencryptedConnectionMessage(long messageId, byte[] body)
        {
            MessageId = messageId;
            Body = body;
        }

        public UnencryptedConnectionMessage(byte[] payload)
        {
            Body = null!;
            if (payload.Length == 4)
            {
                Body = payload;
            }
            else
            {
                Import(payload);
            }
        }

        public void Import(byte[] message)
        {
            using (var reader = new BinaryReader(message.ToMemoryStream()))
            {
                reader.BaseStream.Seek(8, SeekOrigin.Current);
                MessageId = reader.ReadInt64();
                var length = reader.ReadInt32();
                Body = reader.ReadBytes(length);
            }
        }

        public byte[] Export()
        {
            using (var writer = new BinaryWriter(new MemoryStream()))
            {
                writer.Write(AuthKeyId);
                writer.Write(MessageId);
                writer.Write(Body.Length);
                writer.Write(Body);
                return ((MemoryStream)writer.BaseStream).ToArray();
            }
        }
    }
}