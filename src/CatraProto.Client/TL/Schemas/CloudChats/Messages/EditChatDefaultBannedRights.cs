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
    public partial class EditChatDefaultBannedRights : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1517917375; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("banned_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase BannedRights { get; set; }


#nullable enable
        public EditChatDefaultBannedRights(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase bannedRights)
        {
            Peer = peer;
            BannedRights = bannedRights;
        }
#nullable disable

        internal EditChatDefaultBannedRights()
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

            var checkbannedRights = writer.WriteObject(BannedRights);
            if (checkbannedRights.IsError)
            {
                return checkbannedRights;
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
            var trybannedRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
            if (trybannedRights.IsError)
            {
                return ReadResult<IObject>.Move(trybannedRights);
            }

            BannedRights = trybannedRights.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.editChatDefaultBannedRights";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new EditChatDefaultBannedRights();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneBannedRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase?)BannedRights.Clone();
            if (cloneBannedRights is null)
            {
                return null;
            }

            newClonedObject.BannedRights = cloneBannedRights;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not EditChatDefaultBannedRights castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (BannedRights.Compare(castedOther.BannedRights))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}