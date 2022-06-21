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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1776926890; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
            var newClonedObject = new MessageActionPaymentSent
            {
                Flags = Flags,
                RecurringInit = RecurringInit,
                RecurringUsed = RecurringUsed,
                Currency = Currency,
                TotalAmount = TotalAmount,
                InvoiceSlug = InvoiceSlug
            };
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