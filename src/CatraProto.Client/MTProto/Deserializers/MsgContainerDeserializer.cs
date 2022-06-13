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

using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Interfaces.Deserializers;
using CatraProto.TL.Results;
using Serilog;

namespace CatraProto.Client.MTProto.Deserializers
{
    internal class MsgContainerDeserializer : IObjectParser
    {
        private readonly ILogger? _logger;
        public MsgContainerDeserializer(ILogger? logger = null)
        {
            if (logger is not null)
            {
                logger = logger.ForContext<MsgContainer>();
            }

            _logger = logger;
        }

        public ReadResult<IObject> ReadObject(IObject obj, Reader reader)
        {
            var msg = (Message)obj;
            var trymsgId = reader.ReadInt64();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }
            msg.MsgId = trymsgId.Value;
            var tryseqno = reader.ReadInt32();
            if (tryseqno.IsError)
            {
                return ReadResult<IObject>.Move(tryseqno);
            }
            msg.Seqno = tryseqno.Value;
            var trybytes = reader.ReadInt32();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }
            msg.Bytes = trybytes.Value;
            var nowPosition = reader.Stream.Position;
            var trybody = reader.ReadObject<IObject>();
            if (trybody.IsError)
            {
                _logger?.Information("Failed to read message body of length {Lenght} bytes, seeking stream and skipping message", msg.Bytes);
                reader.Stream.Position = nowPosition + msg.Bytes;
                msg.Body = new MessageFailed();
            }
            else
            {
                msg.Body = trybody.Value;
            }

            return new ReadResult<IObject>(msg);
        }

        public bool CanReadObject(IObject obj)
        {
            return obj is Message;
        }
    }
}
