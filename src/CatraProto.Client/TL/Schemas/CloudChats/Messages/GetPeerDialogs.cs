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
    public partial class GetPeerDialogs : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -462373635; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> Peers { get; set; }


#nullable enable
        public GetPeerDialogs(List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase> peers)
        {
            Peers = peers;
        }
#nullable disable

        internal GetPeerDialogs()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeers = writer.WriteVector(Peers, false);
            if (checkpeers.IsError)
            {
                return checkpeers;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypeers.IsError)
            {
                return ReadResult<IObject>.Move(trypeers);
            }

            Peers = trypeers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getPeerDialogs";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetPeerDialogs();
            newClonedObject.Peers = new List<CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase>();
            foreach (var peers in Peers)
            {
                var clonepeers = (CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase?)peers.Clone();
                if (clonepeers is null)
                {
                    return null;
                }

                newClonedObject.Peers.Add(clonepeers);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetPeerDialogs castedOther)
            {
                return true;
            }

            var peerssize = castedOther.Peers.Count;
            if (peerssize != Peers.Count)
            {
                return true;
            }

            for (var i = 0; i < peerssize; i++)
            {
                if (castedOther.Peers[i].Compare(Peers[i]))
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}