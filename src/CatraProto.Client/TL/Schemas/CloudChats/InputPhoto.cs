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
    public partial class InputPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1001634122; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("file_reference")]
        public byte[] FileReference { get; set; }


#nullable enable
        public InputPhoto(long id, long accessHash, byte[] fileReference)
        {
            Id = id;
            AccessHash = accessHash;
            FileReference = fileReference;
        }
#nullable disable
        internal InputPhoto()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPhoto();
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.FileReference = FileReference;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPhoto castedOther)
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

            return false;
        }

#nullable disable
    }
}