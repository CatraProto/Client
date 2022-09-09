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
    public partial class UpdatePeerSettings : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1786671974; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }


#nullable enable
        public UpdatePeerSettings(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase settings)
        {
            Peer = peer;
            Settings = settings;
        }
#nullable disable
        internal UpdatePeerSettings()
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

            var checksettings = writer.WriteObject(Settings);
            if (checksettings.IsError)
            {
                return checksettings;
            }

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
            var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>();
            if (trysettings.IsError)
            {
                return ReadResult<IObject>.Move(trysettings);
            }

            Settings = trysettings.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updatePeerSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdatePeerSettings();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneSettings = (CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase?)Settings.Clone();
            if (cloneSettings is null)
            {
                return null;
            }

            newClonedObject.Settings = cloneSettings;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdatePeerSettings castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Settings.Compare(castedOther.Settings))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}