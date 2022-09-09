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
    public partial class PostAddress : CatraProto.Client.TL.Schemas.CloudChats.PostAddressBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 512535275; }

        [Newtonsoft.Json.JsonProperty("street_line1")]
        public sealed override string StreetLine1 { get; set; }

        [Newtonsoft.Json.JsonProperty("street_line2")]
        public sealed override string StreetLine2 { get; set; }

        [Newtonsoft.Json.JsonProperty("city")] public sealed override string City { get; set; }

        [Newtonsoft.Json.JsonProperty("state")]
        public sealed override string State { get; set; }

        [Newtonsoft.Json.JsonProperty("country_iso2")]
        public sealed override string CountryIso2 { get; set; }

        [Newtonsoft.Json.JsonProperty("post_code")]
        public sealed override string PostCode { get; set; }


#nullable enable
        public PostAddress(string streetLine1, string streetLine2, string city, string state, string countryIso2, string postCode)
        {
            StreetLine1 = streetLine1;
            StreetLine2 = streetLine2;
            City = city;
            State = state;
            CountryIso2 = countryIso2;
            PostCode = postCode;
        }
#nullable disable
        internal PostAddress()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(StreetLine1);

            writer.WriteString(StreetLine2);

            writer.WriteString(City);

            writer.WriteString(State);

            writer.WriteString(CountryIso2);

            writer.WriteString(PostCode);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystreetLine1 = reader.ReadString();
            if (trystreetLine1.IsError)
            {
                return ReadResult<IObject>.Move(trystreetLine1);
            }

            StreetLine1 = trystreetLine1.Value;
            var trystreetLine2 = reader.ReadString();
            if (trystreetLine2.IsError)
            {
                return ReadResult<IObject>.Move(trystreetLine2);
            }

            StreetLine2 = trystreetLine2.Value;
            var trycity = reader.ReadString();
            if (trycity.IsError)
            {
                return ReadResult<IObject>.Move(trycity);
            }

            City = trycity.Value;
            var trystate = reader.ReadString();
            if (trystate.IsError)
            {
                return ReadResult<IObject>.Move(trystate);
            }

            State = trystate.Value;
            var trycountryIso2 = reader.ReadString();
            if (trycountryIso2.IsError)
            {
                return ReadResult<IObject>.Move(trycountryIso2);
            }

            CountryIso2 = trycountryIso2.Value;
            var trypostCode = reader.ReadString();
            if (trypostCode.IsError)
            {
                return ReadResult<IObject>.Move(trypostCode);
            }

            PostCode = trypostCode.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "postAddress";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PostAddress();
            newClonedObject.StreetLine1 = StreetLine1;
            newClonedObject.StreetLine2 = StreetLine2;
            newClonedObject.City = City;
            newClonedObject.State = State;
            newClonedObject.CountryIso2 = CountryIso2;
            newClonedObject.PostCode = PostCode;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PostAddress castedOther)
            {
                return true;
            }

            if (StreetLine1 != castedOther.StreetLine1)
            {
                return true;
            }

            if (StreetLine2 != castedOther.StreetLine2)
            {
                return true;
            }

            if (City != castedOther.City)
            {
                return true;
            }

            if (State != castedOther.State)
            {
                return true;
            }

            if (CountryIso2 != castedOther.CountryIso2)
            {
                return true;
            }

            if (PostCode != castedOther.PostCode)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}