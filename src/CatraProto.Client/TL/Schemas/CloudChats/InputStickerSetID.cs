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
    public partial class InputStickerSetID : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1645763991; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }


#nullable enable
        public InputStickerSetID(long id, long accessHash)
        {
            Id = id;
            AccessHash = accessHash;
        }
#nullable disable
        internal InputStickerSetID()
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
            return "inputStickerSetID";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickerSetID();
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputStickerSetID castedOther)
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