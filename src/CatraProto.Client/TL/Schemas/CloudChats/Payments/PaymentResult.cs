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
    public partial class PaymentResult : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1314881805; }

        [Newtonsoft.Json.JsonProperty("updates")]
        public CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase Updates { get; set; }


#nullable enable
        public PaymentResult(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase updates)
        {
            Updates = updates;

        }
#nullable disable
        internal PaymentResult()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkupdates = writer.WriteObject(Updates);
            if (checkupdates.IsError)
            {
                return checkupdates;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryupdates = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>();
            if (tryupdates.IsError)
            {
                return ReadResult<IObject>.Move(tryupdates);
            }
            Updates = tryupdates.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "payments.paymentResult";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PaymentResult();
            var cloneUpdates = (CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase?)Updates.Clone();
            if (cloneUpdates is null)
            {
                return null;
            }
            newClonedObject.Updates = cloneUpdates;
            return newClonedObject;

        }
#nullable disable
    }
}