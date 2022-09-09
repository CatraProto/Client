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
    public partial class InputBotInlineMessageID64 : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1227287081; }

        [Newtonsoft.Json.JsonProperty("dc_id")]
        public sealed override int DcId { get; set; }

        [Newtonsoft.Json.JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }


#nullable enable
        public InputBotInlineMessageID64(int dcId, long ownerId, int id, long accessHash)
        {
            DcId = dcId;
            OwnerId = ownerId;
            Id = id;
            AccessHash = accessHash;
        }
#nullable disable
        internal InputBotInlineMessageID64()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(DcId);
            writer.WriteInt64(OwnerId);
            writer.WriteInt32(Id);
            writer.WriteInt64(AccessHash);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydcId = reader.ReadInt32();
            if (trydcId.IsError)
            {
                return ReadResult<IObject>.Move(trydcId);
            }

            DcId = trydcId.Value;
            var tryownerId = reader.ReadInt64();
            if (tryownerId.IsError)
            {
                return ReadResult<IObject>.Move(tryownerId);
            }

            OwnerId = tryownerId.Value;
            var tryid = reader.ReadInt32();
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
            return "inputBotInlineMessageID64";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputBotInlineMessageID64();
            newClonedObject.DcId = DcId;
            newClonedObject.OwnerId = OwnerId;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputBotInlineMessageID64 castedOther)
            {
                return true;
            }

            if (DcId != castedOther.DcId)
            {
                return true;
            }

            if (OwnerId != castedOther.OwnerId)
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