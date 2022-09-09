using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class Support : CatraProto.Client.TL.Schemas.CloudChats.Help.SupportBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 398898678; }

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public sealed override string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("user")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.UserBase User { get; set; }


#nullable enable
        public Support(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.UserBase user)
        {
            PhoneNumber = phoneNumber;
            User = user;
        }
#nullable disable
        internal Support()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneNumber);
            var checkuser = writer.WriteObject(User);
            if (checkuser.IsError)
            {
                return checkuser;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneNumber = reader.ReadString();
            if (tryphoneNumber.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneNumber);
            }

            PhoneNumber = tryphoneNumber.Value;
            var tryuser = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            if (tryuser.IsError)
            {
                return ReadResult<IObject>.Move(tryuser);
            }

            User = tryuser.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.support";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Support();
            newClonedObject.PhoneNumber = PhoneNumber;
            var cloneUser = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)User.Clone();
            if (cloneUser is null)
            {
                return null;
            }

            newClonedObject.User = cloneUser;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Support castedOther)
            {
                return true;
            }

            if (PhoneNumber != castedOther.PhoneNumber)
            {
                return true;
            }

            if (User.Compare(castedOther.User))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}