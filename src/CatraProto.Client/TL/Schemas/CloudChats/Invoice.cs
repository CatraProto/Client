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
    public partial class Invoice : CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Test = 1 << 0,
            NameRequested = 1 << 1,
            PhoneRequested = 1 << 2,
            EmailRequested = 1 << 3,
            ShippingAddressRequested = 1 << 4,
            Flexible = 1 << 5,
            PhoneToProvider = 1 << 6,
            EmailToProvider = 1 << 7,
            Recurring = 1 << 9,
            MaxTipAmount = 1 << 8,
            SuggestedTipAmounts = 1 << 8,
            RecurringTermsUrl = 1 << 9
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1048946971; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("test")] public sealed override bool Test { get; set; }

        [Newtonsoft.Json.JsonProperty("name_requested")]
        public sealed override bool NameRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_requested")]
        public sealed override bool PhoneRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("email_requested")]
        public sealed override bool EmailRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("shipping_address_requested")]
        public sealed override bool ShippingAddressRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("flexible")]
        public sealed override bool Flexible { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_to_provider")]
        public sealed override bool PhoneToProvider { get; set; }

        [Newtonsoft.Json.JsonProperty("email_to_provider")]
        public sealed override bool EmailToProvider { get; set; }

        [Newtonsoft.Json.JsonProperty("recurring")]
        public sealed override bool Recurring { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public sealed override string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("prices")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }

        [Newtonsoft.Json.JsonProperty("max_tip_amount")]
        public sealed override long? MaxTipAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("suggested_tip_amounts")]
        public sealed override List<long> SuggestedTipAmounts { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("recurring_terms_url")]
        public sealed override string RecurringTermsUrl { get; set; }


#nullable enable
        public Invoice(string currency, List<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> prices)
        {
            Currency = currency;
            Prices = prices;
        }
#nullable disable
        internal Invoice()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Test ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = NameRequested ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = PhoneRequested ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = EmailRequested ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = ShippingAddressRequested ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Flexible ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = PhoneToProvider ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = EmailToProvider ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = Recurring ? FlagsHelper.SetFlag(Flags, 9) : FlagsHelper.UnsetFlag(Flags, 9);
            Flags = MaxTipAmount == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
            Flags = SuggestedTipAmounts == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
            Flags = RecurringTermsUrl == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Currency);
            var checkprices = writer.WriteVector(Prices, false);
            if (checkprices.IsError)
            {
                return checkprices;
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                writer.WriteInt64(MaxTipAmount.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                writer.WriteVector(SuggestedTipAmounts, false);
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                writer.WriteString(RecurringTermsUrl);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Test = FlagsHelper.IsFlagSet(Flags, 0);
            NameRequested = FlagsHelper.IsFlagSet(Flags, 1);
            PhoneRequested = FlagsHelper.IsFlagSet(Flags, 2);
            EmailRequested = FlagsHelper.IsFlagSet(Flags, 3);
            ShippingAddressRequested = FlagsHelper.IsFlagSet(Flags, 4);
            Flexible = FlagsHelper.IsFlagSet(Flags, 5);
            PhoneToProvider = FlagsHelper.IsFlagSet(Flags, 6);
            EmailToProvider = FlagsHelper.IsFlagSet(Flags, 7);
            Recurring = FlagsHelper.IsFlagSet(Flags, 9);
            var trycurrency = reader.ReadString();
            if (trycurrency.IsError)
            {
                return ReadResult<IObject>.Move(trycurrency);
            }

            Currency = trycurrency.Value;
            var tryprices = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryprices.IsError)
            {
                return ReadResult<IObject>.Move(tryprices);
            }

            Prices = tryprices.Value;
            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var trymaxTipAmount = reader.ReadInt64();
                if (trymaxTipAmount.IsError)
                {
                    return ReadResult<IObject>.Move(trymaxTipAmount);
                }

                MaxTipAmount = trymaxTipAmount.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var trysuggestedTipAmounts = reader.ReadVector<long>(ParserTypes.Int64);
                if (trysuggestedTipAmounts.IsError)
                {
                    return ReadResult<IObject>.Move(trysuggestedTipAmounts);
                }

                SuggestedTipAmounts = trysuggestedTipAmounts.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var tryrecurringTermsUrl = reader.ReadString();
                if (tryrecurringTermsUrl.IsError)
                {
                    return ReadResult<IObject>.Move(tryrecurringTermsUrl);
                }

                RecurringTermsUrl = tryrecurringTermsUrl.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "invoice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Invoice();
            newClonedObject.Flags = Flags;
            newClonedObject.Test = Test;
            newClonedObject.NameRequested = NameRequested;
            newClonedObject.PhoneRequested = PhoneRequested;
            newClonedObject.EmailRequested = EmailRequested;
            newClonedObject.ShippingAddressRequested = ShippingAddressRequested;
            newClonedObject.Flexible = Flexible;
            newClonedObject.PhoneToProvider = PhoneToProvider;
            newClonedObject.EmailToProvider = EmailToProvider;
            newClonedObject.Recurring = Recurring;
            newClonedObject.Currency = Currency;
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

            newClonedObject.MaxTipAmount = MaxTipAmount;
            if (SuggestedTipAmounts is not null)
            {
                newClonedObject.SuggestedTipAmounts = new List<long>();
                foreach (var suggestedTipAmounts in SuggestedTipAmounts)
                {
                    newClonedObject.SuggestedTipAmounts.Add(suggestedTipAmounts);
                }
            }

            newClonedObject.RecurringTermsUrl = RecurringTermsUrl;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Invoice castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Test != castedOther.Test)
            {
                return true;
            }

            if (NameRequested != castedOther.NameRequested)
            {
                return true;
            }

            if (PhoneRequested != castedOther.PhoneRequested)
            {
                return true;
            }

            if (EmailRequested != castedOther.EmailRequested)
            {
                return true;
            }

            if (ShippingAddressRequested != castedOther.ShippingAddressRequested)
            {
                return true;
            }

            if (Flexible != castedOther.Flexible)
            {
                return true;
            }

            if (PhoneToProvider != castedOther.PhoneToProvider)
            {
                return true;
            }

            if (EmailToProvider != castedOther.EmailToProvider)
            {
                return true;
            }

            if (Recurring != castedOther.Recurring)
            {
                return true;
            }

            if (Currency != castedOther.Currency)
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

            if (MaxTipAmount != castedOther.MaxTipAmount)
            {
                return true;
            }

            if (SuggestedTipAmounts is null && castedOther.SuggestedTipAmounts is not null || SuggestedTipAmounts is not null && castedOther.SuggestedTipAmounts is null)
            {
                return true;
            }

            if (SuggestedTipAmounts is not null && castedOther.SuggestedTipAmounts is not null)
            {
                var suggestedTipAmountssize = castedOther.SuggestedTipAmounts.Count;
                if (suggestedTipAmountssize != SuggestedTipAmounts.Count)
                {
                    return true;
                }

                for (var i = 0; i < suggestedTipAmountssize; i++)
                {
                    if (castedOther.SuggestedTipAmounts[i] != SuggestedTipAmounts[i])
                    {
                        return true;
                    }
                }
            }

            if (RecurringTermsUrl != castedOther.RecurringTermsUrl)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}