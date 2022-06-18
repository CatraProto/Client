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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PaymentSavedCredentialsCard : CatraProto.Client.TL.Schemas.CloudChats.PaymentSavedCredentialsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -842892769; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }


#nullable enable
        public PaymentSavedCredentialsCard(string id, string title)
        {
            Id = id;
            Title = title;

        }
#nullable disable
        internal PaymentSavedCredentialsCard()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Id);

            writer.WriteString(Title);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadString();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "paymentSavedCredentialsCard";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PaymentSavedCredentialsCard
            {
                Id = Id,
                Title = Title
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PaymentSavedCredentialsCard castedOther)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (Title != castedOther.Title)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}