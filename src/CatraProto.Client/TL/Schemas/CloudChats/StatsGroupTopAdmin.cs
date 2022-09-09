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
    public partial class StatsGroupTopAdmin : CatraProto.Client.TL.Schemas.CloudChats.StatsGroupTopAdminBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -682079097; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("deleted")]
        public sealed override int Deleted { get; set; }

        [Newtonsoft.Json.JsonProperty("kicked")]
        public sealed override int Kicked { get; set; }

        [Newtonsoft.Json.JsonProperty("banned")]
        public sealed override int Banned { get; set; }


#nullable enable
        public StatsGroupTopAdmin(long userId, int deleted, int kicked, int banned)
        {
            UserId = userId;
            Deleted = deleted;
            Kicked = kicked;
            Banned = banned;
        }
#nullable disable
        internal StatsGroupTopAdmin()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Deleted);
            writer.WriteInt32(Kicked);
            writer.WriteInt32(Banned);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trydeleted = reader.ReadInt32();
            if (trydeleted.IsError)
            {
                return ReadResult<IObject>.Move(trydeleted);
            }

            Deleted = trydeleted.Value;
            var trykicked = reader.ReadInt32();
            if (trykicked.IsError)
            {
                return ReadResult<IObject>.Move(trykicked);
            }

            Kicked = trykicked.Value;
            var trybanned = reader.ReadInt32();
            if (trybanned.IsError)
            {
                return ReadResult<IObject>.Move(trybanned);
            }

            Banned = trybanned.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "statsGroupTopAdmin";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsGroupTopAdmin();
            newClonedObject.UserId = UserId;
            newClonedObject.Deleted = Deleted;
            newClonedObject.Kicked = Kicked;
            newClonedObject.Banned = Banned;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsGroupTopAdmin castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Deleted != castedOther.Deleted)
            {
                return true;
            }

            if (Kicked != castedOther.Kicked)
            {
                return true;
            }

            if (Banned != castedOther.Banned)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}