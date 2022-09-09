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
    public partial class EncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.EncryptedFileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1476358952; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("size")] public long Size { get; set; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("key_fingerprint")]
        public int KeyFingerprint { get; set; }


#nullable enable
        public EncryptedFile(long id, long accessHash, long size, int dcId, int keyFingerprint)
        {
            Id = id;
            AccessHash = accessHash;
            Size = size;
            DcId = dcId;
            KeyFingerprint = keyFingerprint;
        }
#nullable disable
        internal EncryptedFile()
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
            writer.WriteInt64(Size);
            writer.WriteInt32(DcId);
            writer.WriteInt32(KeyFingerprint);

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
            var trysize = reader.ReadInt64();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }

            Size = trysize.Value;
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }

            DcId = trydcId.Value;
            var trykeyFingerprint = reader.ReadInt32();
            if (trykeyFingerprint.IsError)
            {
                return ReadResult<IObject>.Move(trykeyFingerprint);
            }

            KeyFingerprint = trykeyFingerprint.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "encryptedFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EncryptedFile();
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.Size = Size;
            newClonedObject.DcId = DcId;
            newClonedObject.KeyFingerprint = KeyFingerprint;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not EncryptedFile castedOther)
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

            if (Size != castedOther.Size)
            {
                return true;
            }

            if (DcId != castedOther.DcId)
            {
                return true;
            }

            if (KeyFingerprint != castedOther.KeyFingerprint)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}