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
    public partial class GetMessagesViews : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1468322785; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public List<int> Id { get; set; }

        [Newtonsoft.Json.JsonProperty("increment")]
        public bool Increment { get; set; }


#nullable enable
        public GetMessagesViews(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<int> id, bool increment)
        {
            Peer = peer;
            Id = id;
            Increment = increment;
        }
#nullable disable

        internal GetMessagesViews()
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

            writer.WriteVector(Id, false);
            var checkincrement = writer.WriteBool(Increment);
            if (checkincrement.IsError)
            {
                return checkincrement;
            }

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
            var tryid = reader.ReadVector<int>(ParserTypes.Int);
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryincrement = reader.ReadBool();
            if (tryincrement.IsError)
            {
                return ReadResult<IObject>.Move(tryincrement);
            }

            Increment = tryincrement.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getMessagesViews";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetMessagesViews();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Id = new List<int>();
            foreach (var id in Id)
            {
                newClonedObject.Id.Add(id);
            }

            newClonedObject.Increment = Increment;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetMessagesViews castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            var idsize = castedOther.Id.Count;
            if (idsize != Id.Count)
            {
                return true;
            }

            for (var i = 0; i < idsize; i++)
            {
                if (castedOther.Id[i] != Id[i])
                {
                    return true;
                }
            }

            if (Increment != castedOther.Increment)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}