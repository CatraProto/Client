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
    public partial class StatsAbsValueAndPrev : CatraProto.Client.TL.Schemas.CloudChats.StatsAbsValueAndPrevBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -884757282; }

        [Newtonsoft.Json.JsonProperty("current")]
        public sealed override double Current { get; set; }

        [Newtonsoft.Json.JsonProperty("previous")]
        public sealed override double Previous { get; set; }


#nullable enable
        public StatsAbsValueAndPrev(double current, double previous)
        {
            Current = current;
            Previous = previous;
        }
#nullable disable
        internal StatsAbsValueAndPrev()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteDouble(Current);

            writer.WriteDouble(Previous);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycurrent = reader.ReadDouble();
            if (trycurrent.IsError)
            {
                return ReadResult<IObject>.Move(trycurrent);
            }

            Current = trycurrent.Value;
            var tryprevious = reader.ReadDouble();
            if (tryprevious.IsError)
            {
                return ReadResult<IObject>.Move(tryprevious);
            }

            Previous = tryprevious.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "statsAbsValueAndPrev";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StatsAbsValueAndPrev();
            newClonedObject.Current = Current;
            newClonedObject.Previous = Previous;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not StatsAbsValueAndPrev castedOther)
            {
                return true;
            }

            if (Current != castedOther.Current)
            {
                return true;
            }

            if (Previous != castedOther.Previous)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}