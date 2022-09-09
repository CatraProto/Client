using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class SendPaymentForm : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            RequestedInfoId = 1 << 0,
            ShippingOptionId = 1 << 1,
            TipAmount = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 755192367; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("form_id")]
        public long FormId { get; set; }

        [Newtonsoft.Json.JsonProperty("invoice")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase Invoice { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("requested_info_id")]
        public string RequestedInfoId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping_option_id")]
        public string ShippingOptionId { get; set; }

        [Newtonsoft.Json.JsonProperty("credentials")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase Credentials { get; set; }

        [Newtonsoft.Json.JsonProperty("tip_amount")]
        public long? TipAmount { get; set; }


#nullable enable
        public SendPaymentForm(long formId, CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase invoice, CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase credentials)
        {
            FormId = formId;
            Invoice = invoice;
            Credentials = credentials;
        }
#nullable disable

        internal SendPaymentForm()
        {
        }

        public void UpdateFlags()
        {
            Flags = RequestedInfoId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = TipAmount == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(FormId);
            var checkinvoice = writer.WriteObject(Invoice);
            if (checkinvoice.IsError)
            {
                return checkinvoice;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(RequestedInfoId);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(ShippingOptionId);
            }

            var checkcredentials = writer.WriteObject(Credentials);
            if (checkcredentials.IsError)
            {
                return checkcredentials;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt64(TipAmount.Value);
            }


            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var tryformId = reader.ReadInt64();
            if (tryformId.IsError)
            {
                return ReadResult<IObject>.Move(tryformId);
            }

            FormId = tryformId.Value;
            var tryinvoice = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase>();
            if (tryinvoice.IsError)
            {
                return ReadResult<IObject>.Move(tryinvoice);
            }

            Invoice = tryinvoice.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryrequestedInfoId = reader.ReadString();
                if (tryrequestedInfoId.IsError)
                {
                    return ReadResult<IObject>.Move(tryrequestedInfoId);
                }

                RequestedInfoId = tryrequestedInfoId.Value;
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

            var trycredentials = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase>();
            if (trycredentials.IsError)
            {
                return ReadResult<IObject>.Move(trycredentials);
            }

            Credentials = trycredentials.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trytipAmount = reader.ReadInt64();
                if (trytipAmount.IsError)
                {
                    return ReadResult<IObject>.Move(trytipAmount);
                }

                TipAmount = trytipAmount.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.sendPaymentForm";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendPaymentForm();
            newClonedObject.Flags = Flags;
            newClonedObject.FormId = FormId;
            var cloneInvoice = (CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase?)Invoice.Clone();
            if (cloneInvoice is null)
            {
                return null;
            }

            newClonedObject.Invoice = cloneInvoice;
            newClonedObject.RequestedInfoId = RequestedInfoId;
            newClonedObject.ShippingOptionId = ShippingOptionId;
            var cloneCredentials = (CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase?)Credentials.Clone();
            if (cloneCredentials is null)
            {
                return null;
            }

            newClonedObject.Credentials = cloneCredentials;
            newClonedObject.TipAmount = TipAmount;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendPaymentForm castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (FormId != castedOther.FormId)
            {
                return true;
            }

            if (Invoice.Compare(castedOther.Invoice))
            {
                return true;
            }

            if (RequestedInfoId != castedOther.RequestedInfoId)
            {
                return true;
            }

            if (ShippingOptionId != castedOther.ShippingOptionId)
            {
                return true;
            }

            if (Credentials.Compare(castedOther.Credentials))
            {
                return true;
            }

            if (TipAmount != castedOther.TipAmount)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}