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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InvoiceBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("test")]
        public abstract bool Test { get; set; }

        [Newtonsoft.Json.JsonProperty("name_requested")]
        public abstract bool NameRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_requested")]
        public abstract bool PhoneRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("email_requested")]
        public abstract bool EmailRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("shipping_address_requested")]
        public abstract bool ShippingAddressRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("flexible")]
        public abstract bool Flexible { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_to_provider")]
        public abstract bool PhoneToProvider { get; set; }

        [Newtonsoft.Json.JsonProperty("email_to_provider")]
        public abstract bool EmailToProvider { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public abstract string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("prices")]
        public abstract List<CatraProto.Client.TL.Schemas.CloudChats.LabeledPriceBase> Prices { get; set; }

        [Newtonsoft.Json.JsonProperty("max_tip_amount")]
        public abstract long? MaxTipAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("suggested_tip_amounts")]
        public abstract List<long> SuggestedTipAmounts { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}
