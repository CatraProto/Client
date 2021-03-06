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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class PingDelayDisconnect : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -213746804; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("ping_id")]
        public long PingId { get; set; }

        [Newtonsoft.Json.JsonProperty("disconnect_delay")]
        public int DisconnectDelay { get; set; }


#nullable enable
        public PingDelayDisconnect(long pingId, int disconnectDelay)
        {
            PingId = pingId;
            DisconnectDelay = disconnectDelay;

        }
#nullable disable

        internal PingDelayDisconnect()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(PingId);
            writer.WriteInt32(DisconnectDelay);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypingId = reader.ReadInt64();
            if (trypingId.IsError)
            {
                return ReadResult<IObject>.Move(trypingId);
            }
            PingId = trypingId.Value;
            var trydisconnectDelay = reader.ReadInt32();
            if (trydisconnectDelay.IsError)
            {
                return ReadResult<IObject>.Move(trydisconnectDelay);
            }
            DisconnectDelay = trydisconnectDelay.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "ping_delay_disconnect";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new PingDelayDisconnect
            {
                PingId = PingId,
                DisconnectDelay = DisconnectDelay
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not PingDelayDisconnect castedOther)
            {
                return true;
            }
            if (PingId != castedOther.PingId)
            {
                return true;
            }
            if (DisconnectDelay != castedOther.DisconnectDelay)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}