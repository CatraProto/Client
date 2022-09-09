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
    public partial class BotInlineMessageMediaInvoice : CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ShippingAddressRequested = 1 << 1,
            Test = 1 << 3,
            Photo = 1 << 0,
            ReplyMarkup = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 894081801; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("shipping_address_requested")]
        public bool ShippingAddressRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("test")] public bool Test { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public long TotalAmount { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reply_markup")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }


#nullable enable
        public BotInlineMessageMediaInvoice(string title, string description, string currency, long totalAmount)
        {
            Title = title;
            Description = description;
            Currency = currency;
            TotalAmount = totalAmount;
        }
#nullable disable
        internal BotInlineMessageMediaInvoice()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ShippingAddressRequested ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Test ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Title);

            writer.WriteString(Description);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkphoto = writer.WriteObject(Photo);
                if (checkphoto.IsError)
                {
                    return checkphoto;
                }
            }


            writer.WriteString(Currency);
            writer.WriteInt64(TotalAmount);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkreplyMarkup = writer.WriteObject(ReplyMarkup);
                if (checkreplyMarkup.IsError)
                {
                    return checkreplyMarkup;
                }
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
            ShippingAddressRequested = FlagsHelper.IsFlagSet(Flags, 1);
            Test = FlagsHelper.IsFlagSet(Flags, 3);
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
                if (tryphoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryphoto);
                }

                Photo = tryphoto.Value;
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
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryreplyMarkup = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
                if (tryreplyMarkup.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyMarkup);
                }

                ReplyMarkup = tryreplyMarkup.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "botInlineMessageMediaInvoice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotInlineMessageMediaInvoice();
            newClonedObject.Flags = Flags;
            newClonedObject.ShippingAddressRequested = ShippingAddressRequested;
            newClonedObject.Test = Test;
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

            newClonedObject.Currency = Currency;
            newClonedObject.TotalAmount = TotalAmount;
            if (ReplyMarkup is not null)
            {
                var cloneReplyMarkup = (CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase?)ReplyMarkup.Clone();
                if (cloneReplyMarkup is null)
                {
                    return null;
                }

                newClonedObject.ReplyMarkup = cloneReplyMarkup;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not BotInlineMessageMediaInvoice castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ShippingAddressRequested != castedOther.ShippingAddressRequested)
            {
                return true;
            }

            if (Test != castedOther.Test)
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

            if (Currency != castedOther.Currency)
            {
                return true;
            }

            if (TotalAmount != castedOther.TotalAmount)
            {
                return true;
            }

            if (ReplyMarkup is null && castedOther.ReplyMarkup is not null || ReplyMarkup is not null && castedOther.ReplyMarkup is null)
            {
                return true;
            }

            if (ReplyMarkup is not null && castedOther.ReplyMarkup is not null && ReplyMarkup.Compare(castedOther.ReplyMarkup))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}