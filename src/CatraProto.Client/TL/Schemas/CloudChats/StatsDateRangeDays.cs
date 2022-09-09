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
    public partial class StatsDateRangeDays : CatraProto.Client.TL.Schemas.CloudChats.StatsDateRangeDaysBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1237848657; }

        [Newtonsoft.Json.JsonProperty("min_date")]
        public sealed override int MinDate { get; set; }

        [Newtonsoft.Json.JsonProperty("max_date")]
        public sealed override int MaxDate { get; set; }


#nullable enable
        public StatsDateRangeDays(int minDate, int maxDate)
        {
            MinDate = minDate;
            MaxDate = maxDate;
        }
#nullable disable
        internal StatsDateRangeDays()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(MinDate);
            writer.WriteInt32(MaxDate);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryminDate = reader.ReadInt32();
            if (tryminDate.IsError)
            {
                return ReadResult<IObject>.Move(tryminDate);
            }

            MinDate = tryminDate.Value;
            var trymaxDate = reader.ReadInt32();
            if (trymaxDate.IsError)
            {
                return ReadResult<IObject>.Move(trymaxDate);
            }

            MaxDate = trymaxDate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "statsDateRangeDays";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsDateRangeDays();
            newClonedObject.MinDate = MinDate;
            newClonedObject.MaxDate = MaxDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsDateRangeDays castedOther)
            {
                return true;
            }

            if (MinDate != castedOther.MinDate)
            {
                return true;
            }

            if (MaxDate != castedOther.MaxDate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}