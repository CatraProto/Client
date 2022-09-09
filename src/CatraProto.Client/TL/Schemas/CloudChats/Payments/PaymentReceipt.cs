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
    public partial class PaymentReceipt : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Photo = 1 << 2,
            Info = 1 << 0,
            Shipping = 1 << 1,
            TipAmount = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1891958275; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public sealed override long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("provider_id")]
        public sealed override long ProviderId { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public sealed override string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("invoice")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("info")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase Shipping { get; set; }

        [Newtonsoft.Json.JsonProperty("tip_amount")]
        public sealed override long? TipAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public sealed override string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public sealed override long TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("credentials_title")]
        public sealed override string CredentialsTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public PaymentReceipt(int date, long botId, long providerId, string title, string description, CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase invoice, string currency, long totalAmount, string credentialsTitle, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Date = date;
            BotId = botId;
            ProviderId = providerId;
            Title = title;
            Description = description;
            Invoice = invoice;
            Currency = currency;
            TotalAmount = totalAmount;
            CredentialsTitle = credentialsTitle;
            Users = users;
        }
#nullable disable
        internal PaymentReceipt()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Info == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Shipping == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = TipAmount == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Date);
            writer.WriteInt64(BotId);
            writer.WriteInt64(ProviderId);

            writer.WriteString(Title);

            writer.WriteString(Description);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkphoto = writer.WriteObject(Photo);
                if (checkphoto.IsError)
                {
                    return checkphoto;
                }
            }

            var checkinvoice = writer.WriteObject(Invoice);
            if (checkinvoice.IsError)
            {
                return checkinvoice;
            }

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
                var checkshipping = writer.WriteObject(Shipping);
                if (checkshipping.IsError)
                {
                    return checkshipping;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt64(TipAmount.Value);
            }


            writer.WriteString(Currency);
            writer.WriteInt64(TotalAmount);

            writer.WriteString(CredentialsTitle);
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
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
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }

            BotId = trybotId.Value;
            var tryproviderId = reader.ReadInt64();
            if (tryproviderId.IsError)
            {
                return ReadResult<IObject>.Move(tryproviderId);
            }

            ProviderId = tryproviderId.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }

            Title = trytitle.Value;
            var trydescription = reader.ReadString();
            if (trydescription.IsError)
            {
                return ReadResult<IObject>.Move(trydescription);
            }

            Description = trydescription.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
                if (tryphoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryphoto);
                }

                Photo = tryphoto.Value;
            }

            var tryinvoice = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
            if (tryinvoice.IsError)
            {
                return ReadResult<IObject>.Move(tryinvoice);
            }

            Invoice = tryinvoice.Value;
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
                var tryshipping = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>();
                if (tryshipping.IsError)
                {
                    return ReadResult<IObject>.Move(tryshipping);
                }

                Shipping = tryshipping.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trytipAmount = reader.ReadInt64();
                if (trytipAmount.IsError)
                {
                    return ReadResult<IObject>.Move(trytipAmount);
                }

                TipAmount = trytipAmount.Value;
            }

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
            var trycredentialsTitle = reader.ReadString();
            if (trycredentialsTitle.IsError)
            {
                return ReadResult<IObject>.Move(trycredentialsTitle);
            }

            CredentialsTitle = trycredentialsTitle.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }

            Users = tryusers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.paymentReceipt";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PaymentReceipt();
            newClonedObject.Flags = Flags;
            newClonedObject.Date = Date;
            newClonedObject.BotId = BotId;
            newClonedObject.ProviderId = ProviderId;
            newClonedObject.Title = Title;
            newClonedObject.Description = Description;
            if (Photo is not null)
            {
                var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase?)Photo.Clone();
                if (clonePhoto is null)
                {
                    return null;
                }

                newClonedObject.Photo = clonePhoto;
            }

            var cloneInvoice = (CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase?)Invoice.Clone();
            if (cloneInvoice is null)
            {
                return null;
            }

            newClonedObject.Invoice = cloneInvoice;
            if (Info is not null)
            {
                var cloneInfo = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)Info.Clone();
                if (cloneInfo is null)
                {
                    return null;
                }

                newClonedObject.Info = cloneInfo;
            }

            if (Shipping is not null)
            {
                var cloneShipping = (CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase?)Shipping.Clone();
                if (cloneShipping is null)
                {
                    return null;
                }

                newClonedObject.Shipping = cloneShipping;
            }

            newClonedObject.TipAmount = TipAmount;
            newClonedObject.Currency = Currency;
            newClonedObject.TotalAmount = TotalAmount;
            newClonedObject.CredentialsTitle = CredentialsTitle;
            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }

                newClonedObject.Users.Add(cloneusers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PaymentReceipt castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (BotId != castedOther.BotId)
            {
                return true;
            }

            if (ProviderId != castedOther.ProviderId)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            if (Description != castedOther.Description)
            {
                return true;
            }

            if (Photo is null && castedOther.Photo is not null || Photo is not null && castedOther.Photo is null)
            {
                return true;
            }

            if (Photo is not null && castedOther.Photo is not null && Photo.Compare(castedOther.Photo))
            {
                return true;
            }

            if (Invoice.Compare(castedOther.Invoice))
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

            if (Shipping is null && castedOther.Shipping is not null || Shipping is not null && castedOther.Shipping is null)
            {
                return true;
            }

            if (Shipping is not null && castedOther.Shipping is not null && Shipping.Compare(castedOther.Shipping))
            {
                return true;
            }

            if (TipAmount != castedOther.TipAmount)
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

            if (CredentialsTitle != castedOther.CredentialsTitle)
            {
                return true;
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}