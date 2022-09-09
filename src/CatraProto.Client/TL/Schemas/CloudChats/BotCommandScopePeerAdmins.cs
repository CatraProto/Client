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
    public partial class BotCommandScopePeerAdmins : CatraProto.Client.TL.Schemas.CloudChats.BotCommandScopeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1071145937; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }


#nullable enable
        public BotCommandScopePeerAdmins(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
        {
            Peer = peer;
        }
#nullable disable
        internal BotCommandScopePeerAdmins()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "botCommandScopePeerAdmins";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotCommandScopePeerAdmins();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BotCommandScopePeerAdmins castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}