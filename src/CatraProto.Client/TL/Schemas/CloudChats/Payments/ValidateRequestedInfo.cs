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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class ValidateRequestedInfo : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Save = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1228345045; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("save")]
        public bool Save { get; set; }

        [Newtonsoft.Json.JsonProperty("invoice")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase Invoice { get; set; }

        [Newtonsoft.Json.JsonProperty("info")]
        public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }


#nullable enable
        public ValidateRequestedInfo(CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase invoice, CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase info)
        {
            Invoice = invoice;
            Info = info;

        }
#nullable disable

        internal ValidateRequestedInfo()
        {
        }

        public void UpdateFlags()
        {
            Flags = Save ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkinvoice = writer.WriteObject(Invoice);
            if (checkinvoice.IsError)
            {
                return checkinvoice;
            }
            var checkinfo = writer.WriteObject(Info);
            if (checkinfo.IsError)
            {
                return checkinfo;
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
            Save = FlagsHelper.IsFlagSet(Flags, 0);
            var tryinvoice = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase>();
            if (tryinvoice.IsError)
            {
                return ReadResult<IObject>.Move(tryinvoice);
            }
            Invoice = tryinvoice.Value;
            var tryinfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
            if (tryinfo.IsError)
            {
                return ReadResult<IObject>.Move(tryinfo);
            }
            Info = tryinfo.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "payments.validateRequestedInfo";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ValidateRequestedInfo
            {
                Flags = Flags,
                Save = Save
            };
            var cloneInvoice = (CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase?)Invoice.Clone();
            if (cloneInvoice is null)
            {
                return null;
            }
            newClonedObject.Invoice = cloneInvoice;
            var cloneInfo = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)Info.Clone();
            if (cloneInfo is null)
            {
                return null;
            }
            newClonedObject.Info = cloneInfo;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ValidateRequestedInfo castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Save != castedOther.Save)
            {
                return true;
            }
            if (Invoice.Compare(castedOther.Invoice))
            {
                return true;
            }
            if (Info.Compare(castedOther.Info))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}