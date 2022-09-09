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
    public partial class AccountDaysTTL : CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1194283041; }

        [Newtonsoft.Json.JsonProperty("days")] public sealed override int Days { get; set; }


#nullable enable
        public AccountDaysTTL(int days)
        {
            Days = days;
        }
#nullable disable
        internal AccountDaysTTL()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Days);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydays = reader.ReadInt32();
            if (trydays.IsError)
            {
                return ReadResult<IObject>.Move(trydays);
            }

            Days = trydays.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "accountDaysTTL";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AccountDaysTTL();
            newClonedObject.Days = Days;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not AccountDaysTTL castedOther)
            {
                return true;
            }

            if (Days != castedOther.Days)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}