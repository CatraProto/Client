using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChatDefaultBannedRights : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1421875280; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("default_banned_rights")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase DefaultBannedRights { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }


#nullable enable
        public UpdateChatDefaultBannedRights(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase defaultBannedRights, int version)
        {
            Peer = peer;
            DefaultBannedRights = defaultBannedRights;
            Version = version;
        }
#nullable disable
        internal UpdateChatDefaultBannedRights()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            var checkdefaultBannedRights = writer.WriteObject(DefaultBannedRights);
            if (checkdefaultBannedRights.IsError)
            {
                return checkdefaultBannedRights;
            }

            writer.WriteInt32(Version);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trydefaultBannedRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
            if (trydefaultBannedRights.IsError)
            {
                return ReadResult<IObject>.Move(trydefaultBannedRights);
            }

            DefaultBannedRights = trydefaultBannedRights.Value;
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }

            Version = tryversion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChatDefaultBannedRights";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChatDefaultBannedRights();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneDefaultBannedRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase?)DefaultBannedRights.Clone();
            if (cloneDefaultBannedRights is null)
            {
                return null;
            }

            newClonedObject.DefaultBannedRights = cloneDefaultBannedRights;
            newClonedObject.Version = Version;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChatDefaultBannedRights castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (DefaultBannedRights.Compare(castedOther.DefaultBannedRights))
            {
                return true;
            }

            if (Version != castedOther.Version)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}