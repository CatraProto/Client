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
    public partial class UploadMedia : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1369162417; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("media")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }


#nullable enable
        public UploadMedia(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media)
        {
            Peer = peer;
            Media = media;
        }
#nullable disable

        internal UploadMedia()
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

            var checkmedia = writer.WriteObject(Media);
            if (checkmedia.IsError)
            {
                return checkmedia;
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
            var trymedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
            if (trymedia.IsError)
            {
                return ReadResult<IObject>.Move(trymedia);
            }

            Media = trymedia.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.uploadMedia";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UploadMedia();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneMedia = (CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase?)Media.Clone();
            if (cloneMedia is null)
            {
                return null;
            }

            newClonedObject.Media = cloneMedia;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UploadMedia castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Media.Compare(castedOther.Media))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}