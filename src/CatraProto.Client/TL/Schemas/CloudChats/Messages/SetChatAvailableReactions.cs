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
    public partial class SetChatAvailableReactions : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 335875750; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("available_reactions")]
        public List<string> AvailableReactions { get; set; }


#nullable enable
        public SetChatAvailableReactions(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, List<string> availableReactions)
        {
            Peer = peer;
            AvailableReactions = availableReactions;
        }
#nullable disable

        internal SetChatAvailableReactions()
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

            writer.WriteVector(AvailableReactions, false);

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
            var tryavailableReactions = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (tryavailableReactions.IsError)
            {
                return ReadResult<IObject>.Move(tryavailableReactions);
            }

            AvailableReactions = tryavailableReactions.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.setChatAvailableReactions";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetChatAvailableReactions();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.AvailableReactions = new List<string>();
            foreach (var availableReactions in AvailableReactions)
            {
                newClonedObject.AvailableReactions.Add(availableReactions);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetChatAvailableReactions castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            var availableReactionssize = castedOther.AvailableReactions.Count;
            if (availableReactionssize != AvailableReactions.Count)
            {
                return true;
            }

            for (var i = 0; i < availableReactionssize; i++)
            {
                if (castedOther.AvailableReactions[i] != AvailableReactions[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}