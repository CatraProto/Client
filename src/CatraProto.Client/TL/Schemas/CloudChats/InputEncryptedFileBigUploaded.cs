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
    public partial class InputEncryptedFileBigUploaded : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 767652808; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("parts")]
        public int Parts { get; set; }

        [Newtonsoft.Json.JsonProperty("key_fingerprint")]
        public int KeyFingerprint { get; set; }


#nullable enable
        public InputEncryptedFileBigUploaded(long id, int parts, int keyFingerprint)
        {
            Id = id;
            Parts = parts;
            KeyFingerprint = keyFingerprint;
        }
#nullable disable
        internal InputEncryptedFileBigUploaded()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);
            writer.WriteInt32(Parts);
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
            var tryparts = reader.ReadInt32();
            if (tryparts.IsError)
            {
                return ReadResult<IObject>.Move(tryparts);
            }

            Parts = tryparts.Value;
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
            return "inputEncryptedFileBigUploaded";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputEncryptedFileBigUploaded();
            newClonedObject.Id = Id;
            newClonedObject.Parts = Parts;
            newClonedObject.KeyFingerprint = KeyFingerprint;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputEncryptedFileBigUploaded castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Parts != castedOther.Parts)
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