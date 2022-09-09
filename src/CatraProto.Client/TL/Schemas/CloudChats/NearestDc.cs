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
    public partial class NearestDc : CatraProto.Client.TL.Schemas.CloudChats.NearestDcBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1910892683; }

        [Newtonsoft.Json.JsonProperty("country")]
        public sealed override string Country { get; set; }

        [Newtonsoft.Json.JsonProperty("this_dc")]
        public sealed override int ThisDc { get; set; }

        [Newtonsoft.Json.JsonProperty("nearest_dc")]
        public sealed override int NearestDcField { get; set; }


#nullable enable
        public NearestDc(string country, int thisDc, int nearestDcField)
        {
            Country = country;
            ThisDc = thisDc;
            NearestDcField = nearestDcField;
        }
#nullable disable
        internal NearestDc()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Country);
            writer.WriteInt32(ThisDc);
            writer.WriteInt32(NearestDcField);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycountry = reader.ReadString();
            if (trycountry.IsError)
            {
                return ReadResult<IObject>.Move(trycountry);
            }

            Country = trycountry.Value;
            var trythisDc = reader.ReadInt32();
            if (trythisDc.IsError)
            {
                return ReadResult<IObject>.Move(trythisDc);
            }

            ThisDc = trythisDc.Value;
            var trynearestDcField = reader.ReadInt32();
            if (trynearestDcField.IsError)
            {
                return ReadResult<IObject>.Move(trynearestDcField);
            }

            NearestDcField = trynearestDcField.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "nearestDc";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new NearestDc();
            newClonedObject.Country = Country;
            newClonedObject.ThisDc = ThisDc;
            newClonedObject.NearestDcField = NearestDcField;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not NearestDc castedOther)
            {
                return true;
            }

            if (Country != castedOther.Country)
            {
                return true;
            }

            if (ThisDc != castedOther.ThisDc)
            {
                return true;
            }

            if (NearestDcField != castedOther.NearestDcField)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}