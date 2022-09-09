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
    public partial class ExportInvoice : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 261206117; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("invoice_media")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase InvoiceMedia { get; set; }


#nullable enable
        public ExportInvoice(CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase invoiceMedia)
        {
            InvoiceMedia = invoiceMedia;
        }
#nullable disable

        internal ExportInvoice()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkinvoiceMedia = writer.WriteObject(InvoiceMedia);
            if (checkinvoiceMedia.IsError)
            {
                return checkinvoiceMedia;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "payments.exportInvoice";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ExportInvoice();
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
            if (other is not ExportInvoice castedOther)
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