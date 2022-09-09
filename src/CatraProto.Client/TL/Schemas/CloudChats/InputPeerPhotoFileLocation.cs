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
    public partial class InputPeerPhotoFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Big = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 925204121; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("big")] public bool Big { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("photo_id")]
        public long PhotoId { get; set; }


#nullable enable
        public InputPeerPhotoFileLocation(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, long photoId)
        {
            Peer = peer;
            PhotoId = photoId;
        }
#nullable disable
        internal InputPeerPhotoFileLocation()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Big ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt64(PhotoId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Big = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryphotoId = reader.ReadInt64();
            if (tryphotoId.IsError)
            {
                return ReadResult<IObject>.Move(tryphotoId);
            }

            PhotoId = tryphotoId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputPeerPhotoFileLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPeerPhotoFileLocation();
            newClonedObject.Flags = Flags;
            newClonedObject.Big = Big;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.PhotoId = PhotoId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPeerPhotoFileLocation castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Big != castedOther.Big)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (PhotoId != castedOther.PhotoId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}