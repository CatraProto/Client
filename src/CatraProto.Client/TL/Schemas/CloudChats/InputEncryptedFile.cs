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
    public partial class InputEncryptedFile : CatraProto.Client.TL.Schemas.CloudChats.InputEncryptedFileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1511503333; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }


#nullable enable
        public InputEncryptedFile(long id, long accessHash)
        {
            Id = id;
            AccessHash = accessHash;
        }
#nullable disable
        internal InputEncryptedFile()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputEncryptedFile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputEncryptedFile();
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputEncryptedFile castedOther)
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

            return false;
        }

#nullable disable
    }
}