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
    public partial class InputMessageEntityMentionName : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 546203849; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public sealed override int Length { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }


#nullable enable
        public InputMessageEntityMentionName(int offset, int length, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId)
        {
            Offset = offset;
            Length = length;
            UserId = userId;
        }
#nullable disable
        internal InputMessageEntityMentionName()
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
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

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
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputMessageEntityMentionName";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMessageEntityMentionName();
            newClonedObject.Offset = Offset;
            newClonedObject.Length = Length;
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputMessageEntityMentionName castedOther)
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

            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}