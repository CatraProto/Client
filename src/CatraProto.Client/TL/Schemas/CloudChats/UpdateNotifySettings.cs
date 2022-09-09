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
    public partial class UpdateNotifySettings : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1094555409; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }


#nullable enable
        public UpdateNotifySettings(CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase notifySettings)
        {
            Peer = peer;
            NotifySettings = notifySettings;
        }
#nullable disable
        internal UpdateNotifySettings()
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

            var checknotifySettings = writer.WriteObject(NotifySettings);
            if (checknotifySettings.IsError)
            {
                return checknotifySettings;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trynotifySettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
            if (trynotifySettings.IsError)
            {
                return ReadResult<IObject>.Move(trynotifySettings);
            }

            NotifySettings = trynotifySettings.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateNotifySettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateNotifySettings();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.NotifyPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneNotifySettings = (CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase?)NotifySettings.Clone();
            if (cloneNotifySettings is null)
            {
                return null;
            }

            newClonedObject.NotifySettings = cloneNotifySettings;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateNotifySettings castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (NotifySettings.Compare(castedOther.NotifySettings))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}