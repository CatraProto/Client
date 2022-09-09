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
    public partial class MessageActionPaymentSent : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            RecurringInit = 1 << 2,
            RecurringUsed = 1 << 3,
            InvoiceSlug = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1776926890; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("recurring_init")]
        public bool RecurringInit { get; set; }

        [Newtonsoft.Json.JsonProperty("recurring_used")]
        public bool RecurringUsed { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public long TotalAmount { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("invoice_slug")]
        public string InvoiceSlug { get; set; }


#nullable enable
        public MessageActionPaymentSent(string currency, long totalAmount)
        {
            Currency = currency;
            TotalAmount = totalAmount;
        }
#nullable disable
        internal MessageActionPaymentSent()
        {
        }

        public override void UpdateFlags()
        {
            Flags = RecurringInit ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = RecurringUsed ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = InvoiceSlug == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Currency);
            writer.WriteInt64(TotalAmount);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(InvoiceSlug);
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryinvoiceSlug = reader.ReadString();
                if (tryinvoiceSlug.IsError)
                {
                    return ReadResult<IObject>.Move(tryinvoiceSlug);
                }

                InvoiceSlug = tryinvoiceSlug.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionPaymentSent";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionPaymentSent();
            newClonedObject.Flags = Flags;
            newClonedObject.RecurringInit = RecurringInit;
            newClonedObject.RecurringUsed = RecurringUsed;
            newClonedObject.Currency = Currency;
            newClonedObject.TotalAmount = TotalAmount;
            newClonedObject.InvoiceSlug = InvoiceSlug;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionPaymentSent castedOther)
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

            if (InvoiceSlug != castedOther.InvoiceSlug)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}