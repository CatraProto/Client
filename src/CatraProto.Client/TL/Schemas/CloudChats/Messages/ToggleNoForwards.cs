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
    public partial class ToggleNoForwards : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1323389022; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("enabled")]
        public bool Enabled { get; set; }


#nullable enable
        public ToggleNoForwards(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, bool enabled)
        {
            Peer = peer;
            Enabled = enabled;
        }
#nullable disable

        internal ToggleNoForwards()
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

            var checkenabled = writer.WriteBool(Enabled);
            if (checkenabled.IsError)
            {
                return checkenabled;
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
            var tryenabled = reader.ReadBool();
            if (tryenabled.IsError)
            {
                return ReadResult<IObject>.Move(tryenabled);
            }

            Enabled = tryenabled.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.toggleNoForwards";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleNoForwards();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Enabled = Enabled;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ToggleNoForwards castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Enabled != castedOther.Enabled)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}