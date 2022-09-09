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
    public partial class MessageActionPaymentSentMe : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            RecurringInit = 1 << 2,
            RecurringUsed = 1 << 3,
            Info = 1 << 0,
            ShippingOptionId = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1892568281; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("recurring_init")]
        public bool RecurringInit { get; set; }

        [Newtonsoft.Json.JsonProperty("recurring_used")]
        public bool RecurringUsed { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public long TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("payload")]
        public byte[] Payload { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("info")]
        public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping_option_id")]
        public string ShippingOptionId { get; set; }

        [Newtonsoft.Json.JsonProperty("charge")]
        public CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase Charge { get; set; }


#nullable enable
        public MessageActionPaymentSentMe(string currency, long totalAmount, byte[] payload, CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase charge)
        {
            Currency = currency;
            TotalAmount = totalAmount;
            Payload = payload;
            Charge = charge;
        }
#nullable disable
        internal MessageActionPaymentSentMe()
        {
        }

        public override void UpdateFlags()
        {
            Flags = RecurringInit ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = RecurringUsed ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Info == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Currency);
            writer.WriteInt64(TotalAmount);

            writer.WriteBytes(Payload);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkinfo = writer.WriteObject(Info);
                if (checkinfo.IsError)
                {
                    return checkinfo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(ShippingOptionId);
            }

            var checkcharge = writer.WriteObject(Charge);
            if (checkcharge.IsError)
            {
                return checkcharge;
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
            RecurringInit = FlagsHelper.IsFlagSet(Flags, 2);
            RecurringUsed = FlagsHelper.IsFlagSet(Flags, 3);
            var trycurrency = reader.ReadString();
            if (trycurrency.IsError)
            {
                return ReadResult<IObject>.Move(trycurrency);
            }

            Currency = trycurrency.Value;
            var trytotalAmount = reader.ReadInt64();
            if (trytotalAmount.IsError)
            {
                return ReadResult<IObject>.Move(trytotalAmount);
            }

            TotalAmount = trytotalAmount.Value;
            var trypayload = reader.ReadBytes();
            if (trypayload.IsError)
            {
                return ReadResult<IObject>.Move(trypayload);
            }

            Payload = trypayload.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryinfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
                if (tryinfo.IsError)
                {
                    return ReadResult<IObject>.Move(tryinfo);
                }

                Info = tryinfo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryshippingOptionId = reader.ReadString();
                if (tryshippingOptionId.IsError)
                {
                    return ReadResult<IObject>.Move(tryshippingOptionId);
                }

                ShippingOptionId = tryshippingOptionId.Value;
            }

            var trycharge = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase>();
            if (trycharge.IsError)
            {
                return ReadResult<IObject>.Move(trycharge);
            }

            Charge = trycharge.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionPaymentSentMe";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionPaymentSentMe();
            newClonedObject.Flags = Flags;
            newClonedObject.RecurringInit = RecurringInit;
            newClonedObject.RecurringUsed = RecurringUsed;
            newClonedObject.Currency = Currency;
            newClonedObject.TotalAmount = TotalAmount;
            newClonedObject.Payload = Payload;
            if (Info is not null)
            {
                var cloneInfo = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)Info.Clone();
                if (cloneInfo is null)
                {
                    return null;
                }

                newClonedObject.Info = cloneInfo;
            }

            newClonedObject.ShippingOptionId = ShippingOptionId;
            var cloneCharge = (CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase?)Charge.Clone();
            if (cloneCharge is null)
            {
                return null;
            }

            newClonedObject.Charge = cloneCharge;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionPaymentSentMe castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (RecurringInit != castedOther.RecurringInit)
            {
                return true;
            }

            if (RecurringUsed != castedOther.RecurringUsed)
            {
                return true;
            }

            if (Currency != castedOther.Currency)
            {
                return true;
            }

            if (TotalAmount != castedOther.TotalAmount)
            {
                return true;
            }

            if (Payload != castedOther.Payload)
            {
                return true;
            }

            if (Info is null && castedOther.Info is not null || Info is not null && castedOther.Info is null)
            {
                return true;
            }

            if (Info is not null && castedOther.Info is not null && Info.Compare(castedOther.Info))
            {
                return true;
            }

            if (ShippingOptionId != castedOther.ShippingOptionId)
            {
                return true;
            }

            if (Charge.Compare(castedOther.Charge))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}