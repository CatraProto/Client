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
    public partial class UpdateDeviceLocked : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 954152242; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("period")]
        public int Period { get; set; }


#nullable enable
        public UpdateDeviceLocked(int period)
        {
            Period = period;
        }
#nullable disable

        internal UpdateDeviceLocked()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Period);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryperiod = reader.ReadInt32();
            if (tryperiod.IsError)
            {
                return ReadResult<IObject>.Move(tryperiod);
            }

            Period = tryperiod.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.updateDeviceLocked";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdateDeviceLocked();
            newClonedObject.Period = Period;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UpdateDeviceLocked castedOther)
            {
                return true;
            }

            if (Period != castedOther.Period)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}