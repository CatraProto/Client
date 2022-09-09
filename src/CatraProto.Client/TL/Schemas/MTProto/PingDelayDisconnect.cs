using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class PingDelayDisconnect : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -213746804; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

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
            var newClonedObject = new PingDelayDisconnect();
            newClonedObject.PingId = PingId;
            newClonedObject.DisconnectDelay = DisconnectDelay;
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