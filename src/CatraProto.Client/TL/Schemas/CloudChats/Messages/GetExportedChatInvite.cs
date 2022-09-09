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
    public partial class GetExportedChatInvite : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1937010524; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("link")] public string Link { get; set; }


#nullable enable
        public GetExportedChatInvite(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string link)
        {
            Peer = peer;
            Link = link;
        }
#nullable disable

        internal GetExportedChatInvite()
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

            writer.WriteString(Link);

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
            var trylink = reader.ReadString();
            if (trylink.IsError)
            {
                return ReadResult<IObject>.Move(trylink);
            }

            Link = trylink.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getExportedChatInvite";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetExportedChatInvite();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Link = Link;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetExportedChatInvite castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Link != castedOther.Link)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}