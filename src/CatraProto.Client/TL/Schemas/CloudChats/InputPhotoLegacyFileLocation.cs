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
    public partial class InputPhotoLegacyFileLocation : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -667654413; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("file_reference")]
        public byte[] FileReference { get; set; }

        [Newtonsoft.Json.JsonProperty("volume_id")]
        public long VolumeId { get; set; }

        [Newtonsoft.Json.JsonProperty("local_id")]
        public int LocalId { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public long Secret { get; set; }


#nullable enable
        public InputPhotoLegacyFileLocation(long id, long accessHash, byte[] fileReference, long volumeId, int localId, long secret)
        {
            Id = id;
            AccessHash = accessHash;
            FileReference = fileReference;
            VolumeId = volumeId;
            LocalId = localId;
            Secret = secret;
        }
#nullable disable
        internal InputPhotoLegacyFileLocation()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);

            writer.WriteBytes(FileReference);
            writer.WriteInt64(VolumeId);
            writer.WriteInt32(LocalId);
            writer.WriteInt64(Secret);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }

            AccessHash = tryaccessHash.Value;
            var tryfileReference = reader.ReadBytes();
            if (tryfileReference.IsError)
            {
                return ReadResult<IObject>.Move(tryfileReference);
            }

            FileReference = tryfileReference.Value;
            var tryvolumeId = reader.ReadInt64();
            if (tryvolumeId.IsError)
            {
                return ReadResult<IObject>.Move(tryvolumeId);
            }

            VolumeId = tryvolumeId.Value;
            var trylocalId = reader.ReadInt32();
            if (trylocalId.IsError)
            {
                return ReadResult<IObject>.Move(trylocalId);
            }

            LocalId = trylocalId.Value;
            var trysecret = reader.ReadInt64();
            if (trysecret.IsError)
            {
                return ReadResult<IObject>.Move(trysecret);
            }

            Secret = trysecret.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputPhotoLegacyFileLocation";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPhotoLegacyFileLocation();
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.FileReference = FileReference;
            newClonedObject.VolumeId = VolumeId;
            newClonedObject.LocalId = LocalId;
            newClonedObject.Secret = Secret;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPhotoLegacyFileLocation castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            if (FileReference != castedOther.FileReference)
            {
                return true;
            }

            if (VolumeId != castedOther.VolumeId)
            {
                return true;
            }

            if (LocalId != castedOther.LocalId)
            {
                return true;
            }

            if (Secret != castedOther.Secret)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}