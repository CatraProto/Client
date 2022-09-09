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
    public partial class MessageEntityMentionName : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -595914432; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public sealed override int Length { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }


#nullable enable
        public MessageEntityMentionName(int offset, int length, long userId)
        {
            Offset = offset;
            Length = length;
            UserId = userId;
        }
#nullable disable
        internal MessageEntityMentionName()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Offset);
            writer.WriteInt32(Length);
            writer.WriteInt64(UserId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }

            Length = trylength.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageEntityMentionName";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageEntityMentionName();
            newClonedObject.Offset = Offset;
            newClonedObject.Length = Length;
            newClonedObject.UserId = UserId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageEntityMentionName castedOther)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            if (Length != castedOther.Length)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}