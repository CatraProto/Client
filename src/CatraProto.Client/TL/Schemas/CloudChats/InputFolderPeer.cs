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
    public partial class InputFolderPeer : CatraProto.Client.TL.Schemas.CloudChats.InputFolderPeerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -70073706; }

        [Newtonsoft.Json.JsonProperty("peer")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public sealed override int FolderId { get; set; }


#nullable enable
        public InputFolderPeer(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int folderId)
        {
            Peer = peer;
            FolderId = folderId;
        }
#nullable disable
        internal InputFolderPeer()
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

            writer.WriteInt32(FolderId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryfolderId = reader.ReadInt32();
            if (tryfolderId.IsError)
            {
                return ReadResult<IObject>.Move(tryfolderId);
            }

            FolderId = tryfolderId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputFolderPeer";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputFolderPeer();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.FolderId = FolderId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputFolderPeer castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}