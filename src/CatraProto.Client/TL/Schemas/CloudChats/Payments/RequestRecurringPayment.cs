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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class RequestRecurringPayment : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 342791565; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

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