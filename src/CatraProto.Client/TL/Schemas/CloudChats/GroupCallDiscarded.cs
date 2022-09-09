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
    public partial class GroupCallDiscarded : CatraProto.Client.TL.Schemas.CloudChats.GroupCallBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2004925620; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public sealed override long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int Duration { get; set; }


#nullable enable
        public GroupCallDiscarded(long id, long accessHash, int duration)
        {
            Id = id;
            AccessHash = accessHash;
            Duration = duration;
        }
#nullable disable
        internal GroupCallDiscarded()
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
            writer.WriteInt32(Duration);

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
            var tryduration = reader.ReadInt32();
            if (tryduration.IsError)
            {
                return ReadResult<IObject>.Move(tryduration);
            }

            Duration = tryduration.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "groupCallDiscarded";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCallDiscarded();
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.Duration = Duration;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCallDiscarded castedOther)
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

            if (Duration != castedOther.Duration)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}