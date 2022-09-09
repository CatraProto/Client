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
    public partial class RequestRecurringPayment : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 342791565; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("recurring_init_charge")]
        public string RecurringInitCharge { get; set; }

        [Newtonsoft.Json.JsonProperty("invoice_media")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase InvoiceMedia { get; set; }


#nullable enable
        public RequestRecurringPayment(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, string recurringInitCharge, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase invoiceMedia)
        {
            UserId = userId;
            RecurringInitCharge = recurringInitCharge;
            InvoiceMedia = invoiceMedia;
        }
#nullable disable

        internal RequestRecurringPayment()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            writer.WriteString(RecurringInitCharge);
            var checkinvoiceMedia = writer.WriteObject(InvoiceMedia);
            if (checkinvoiceMedia.IsError)
            {
                return checkinvoiceMedia;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryrecurringInitCharge = reader.ReadString();
            if (tryrecurringInitCharge.IsError)
            {
                return ReadResult<IObject>.Move(tryrecurringInitCharge);
            }

            RecurringInitCharge = tryrecurringInitCharge.Value;
            var tryinvoiceMedia = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
            if (tryinvoiceMedia.IsError)
            {
                return ReadResult<IObject>.Move(tryinvoiceMedia);
            }

            InvoiceMedia = tryinvoiceMedia.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "payments.requestRecurringPayment";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RequestRecurringPayment();
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            newClonedObject.RecurringInitCharge = RecurringInitCharge;
            var cloneInvoiceMedia = (CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase?)InvoiceMedia.Clone();
            if (cloneInvoiceMedia is null)
            {
                return null;
            }

            newClonedObject.InvoiceMedia = cloneInvoiceMedia;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RequestRecurringPayment castedOther)
            {
                return true;
            }

            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }

            if (RecurringInitCharge != castedOther.RecurringInitCharge)
            {
                return true;
            }

            if (InvoiceMedia.Compare(castedOther.InvoiceMedia))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}