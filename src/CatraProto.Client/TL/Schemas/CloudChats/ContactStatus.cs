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
    public partial class ContactStatus : CatraProto.Client.TL.Schemas.CloudChats.ContactStatusBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 383348795; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("status")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase Status { get; set; }


#nullable enable
        public ContactStatus(long userId, CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase status)
        {
            UserId = userId;
            Status = status;
        }
#nullable disable
        internal ContactStatus()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            var checkstatus = writer.WriteObject(Status);
            if (checkstatus.IsError)
            {
                return checkstatus;
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
            var trystatus = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase>();
            if (trystatus.IsError)
            {
                return ReadResult<IObject>.Move(trystatus);
            }

            Status = trystatus.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contactStatus";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContactStatus();
            newClonedObject.UserId = UserId;
            var cloneStatus = (CatraProto.Client.TL.Schemas.CloudChats.UserStatusBase?)Status.Clone();
            if (cloneStatus is null)
            {
                return null;
            }

            newClonedObject.Status = cloneStatus;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContactStatus castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Status.Compare(castedOther.Status))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}