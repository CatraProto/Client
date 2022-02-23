using System;
using System.Collections.Generic;
using CatraProto.TL;

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

        public static int StaticConstructorId
        {
            get => 215516896;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

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

        [Newtonsoft.Json.JsonProperty("currency")]
        public sealed override string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("prices")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }

        [Newtonsoft.Json.JsonProperty("max_tip_amount")]
        public sealed override long? MaxTipAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("suggested_tip_amounts")]
        public sealed override IList<long> SuggestedTipAmounts { get; set; }


    #nullable enable
        public Invoice(string currency, IList<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> prices)
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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Currency);
            writer.Write(Prices);
            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                writer.Write(MaxTipAmount.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                writer.Write(SuggestedTipAmounts);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Test = FlagsHelper.IsFlagSet(Flags, 0);
            NameRequested = FlagsHelper.IsFlagSet(Flags, 1);
            PhoneRequested = FlagsHelper.IsFlagSet(Flags, 2);
            EmailRequested = FlagsHelper.IsFlagSet(Flags, 3);
            ShippingAddressRequested = FlagsHelper.IsFlagSet(Flags, 4);
            Flexible = FlagsHelper.IsFlagSet(Flags, 5);
            PhoneToProvider = FlagsHelper.IsFlagSet(Flags, 6);
            EmailToProvider = FlagsHelper.IsFlagSet(Flags, 7);
            Currency = reader.Read<string>();
            Prices = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase>();
            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                MaxTipAmount = reader.Read<long>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                SuggestedTipAmounts = reader.ReadVector<long>();
            }
        }

        public override string ToString()
        {
            return "invoice";
        }
    }
}