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
    public partial class Contact : CatraProto.Client.TL.Schemas.CloudChats.ContactBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 341499403; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("mutual")]
        public sealed override bool Mutual { get; set; }


#nullable enable
        public Contact(long userId, bool mutual)
        {
            UserId = userId;
            Mutual = mutual;
        }
#nullable disable
        internal Contact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            var checkmutual = writer.WriteBool(Mutual);
            if (checkmutual.IsError)
            {
                return checkmutual;
            }

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
            var trymutual = reader.ReadBool();
            if (trymutual.IsError)
            {
                return ReadResult<IObject>.Move(trymutual);
            }

            Mutual = trymutual.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contact";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Contact();
            newClonedObject.UserId = UserId;
            newClonedObject.Mutual = Mutual;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Contact castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Mutual != castedOther.Mutual)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}