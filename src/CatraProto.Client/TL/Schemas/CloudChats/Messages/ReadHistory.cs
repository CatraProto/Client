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
    public partial class ReadHistory : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 238054714; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }


#nullable enable
        public ReadHistory(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int maxId)
        {
            Peer = peer;
            MaxId = maxId;
        }
#nullable disable

        internal ReadHistory()
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

            writer.WriteInt32(MaxId);

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
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }

            MaxId = trymaxId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.readHistory";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReadHistory();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.MaxId = MaxId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReadHistory castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (MaxId != castedOther.MaxId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}