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
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public partial class BankCardData : CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1042605427; }

        [Newtonsoft.Json.JsonProperty("title")]
        public sealed override string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("open_urls")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> OpenUrls { get; set; }


#nullable enable
        public BankCardData(string title, List<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> openUrls)
        {
            Title = title;
            OpenUrls = openUrls;

        }
#nullable disable
        internal BankCardData()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Title);
            var checkopenUrls = writer.WriteVector(OpenUrls, false);
            if (checkopenUrls.IsError)
            {
                return checkopenUrls;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            var tryopenUrls = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryopenUrls.IsError)
            {
                return ReadResult<IObject>.Move(tryopenUrls);
            }
            OpenUrls = tryopenUrls.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "payments.bankCardData";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BankCardData
            {
                Title = Title
            };
            foreach (var openUrls in OpenUrls)
            {
                var cloneopenUrls = (CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase?)openUrls.Clone();
                if (cloneopenUrls is null)
                {
                    return null;
                }
                newClonedObject.OpenUrls.Add(cloneopenUrls);
            }
            return newClonedObject;

        }
#nullable disable
    }
}