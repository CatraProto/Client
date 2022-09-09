using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class ResetPasswordRequestedWait : CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordResultBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -370148227; }

        [Newtonsoft.Json.JsonProperty("until_date")]
        public int UntilDate { get; set; }


#nullable enable
        public ResetPasswordRequestedWait(int untilDate)
        {
            UntilDate = untilDate;
        }
#nullable disable
        internal ResetPasswordRequestedWait()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(UntilDate);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuntilDate = reader.ReadInt32();
            if (tryuntilDate.IsError)
            {
                return ReadResult<IObject>.Move(tryuntilDate);
            }

            UntilDate = tryuntilDate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.resetPasswordRequestedWait";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ResetPasswordRequestedWait();
            newClonedObject.UntilDate = UntilDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ResetPasswordRequestedWait castedOther)
            {
                return true;
            }

            if (UntilDate != castedOther.UntilDate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}