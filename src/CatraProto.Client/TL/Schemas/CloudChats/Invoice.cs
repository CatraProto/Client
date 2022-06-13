/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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
            MaxTipAmount = 1 << 8,
            SuggestedTipAmounts = 1 << 8
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 215516896; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("test")]
        public sealed override bool Test { get; set; }

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

        [Newtonsoft.Json.JsonProperty("currency")]
        public sealed override string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("prices")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }

        [Newtonsoft.Json.JsonProperty("max_tip_amount")]
        public sealed override long? MaxTipAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("suggested_tip_amounts")]
        public sealed override List<long> SuggestedTipAmounts { get; set; }


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
            Flags = MaxTipAmount == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
            Flags = SuggestedTipAmounts == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);

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
            var newClonedObject = new Invoice
            {
                Flags = Flags,
                Test = Test,
                NameRequested = NameRequested,
                PhoneRequested = PhoneRequested,
                EmailRequested = EmailRequested,
                ShippingAddressRequested = ShippingAddressRequested,
                Flexible = Flexible,
                PhoneToProvider = PhoneToProvider,
                EmailToProvider = EmailToProvider,
                Currency = Currency,
                Prices = new List<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase>()
            };
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
            return newClonedObject;

        }
#nullable disable
    }
}