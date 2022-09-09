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
    public partial class ResetPasswordOk : CatraProto.Client.TL.Schemas.CloudChats.Account.ResetPasswordResultBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -383330754; }


        public ResetPasswordOk()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.resetPasswordOk";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ResetPasswordOk();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ResetPasswordOk castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}