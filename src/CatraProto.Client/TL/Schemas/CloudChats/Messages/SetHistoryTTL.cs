using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SetHistoryTTL : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1207017500; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("period")]
        public int Period { get; set; }


#nullable enable
        public SetHistoryTTL(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int period)
        {
            Peer = peer;
            Period = period;
        }
#nullable disable

        internal SetHistoryTTL()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(Period);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryperiod = reader.ReadInt32();
            if (tryperiod.IsError)
            {
                return ReadResult<IObject>.Move(tryperiod);
            }

            Period = tryperiod.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.setHistoryTTL";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetHistoryTTL();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Period = Period;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetHistoryTTL castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Period != castedOther.Period)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}