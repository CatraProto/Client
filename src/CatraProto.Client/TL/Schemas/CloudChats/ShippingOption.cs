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
    public partial class ShippingOption : CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1239335713; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("prices")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }


#nullable enable
        public ShippingOption(string id, string title, List<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> prices)
        {
            Id = id;
            Title = title;
            Prices = prices;
        }
#nullable disable
        internal ShippingOption()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Id);

            writer.WriteString(Title);
            var checkprices = writer.WriteVector(Prices, false);
            if (checkprices.IsError)
            {
                return checkprices;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            var tryprices = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryprices.IsError)
            {
                return ReadResult<IObject>.Move(tryprices);
            }

            Prices = tryprices.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "shippingOption";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ShippingOption();
            newClonedObject.Id = Id;
            newClonedObject.Title = Title;
            newClonedObject.Prices = new List<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase>();
            foreach (var prices in Prices)
            {
                var cloneprices = (CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase?)prices.Clone();
                if (cloneprices is null)
                {
                    return null;
                }

                newClonedObject.Prices.Add(cloneprices);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ShippingOption castedOther)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            var pricessize = castedOther.Prices.Count;
            if (pricessize != Prices.Count)
            {
                return true;
            }

            for (var i = 0; i < pricessize; i++)
            {
                if (castedOther.Prices[i].Compare(Prices[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}