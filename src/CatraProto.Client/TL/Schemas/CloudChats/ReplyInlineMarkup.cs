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
    public partial class ReplyInlineMarkup : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1218642516; }

        [Newtonsoft.Json.JsonProperty("rows")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> Rows { get; set; }


#nullable enable
        public ReplyInlineMarkup(List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> rows)
        {
            Rows = rows;

        }
#nullable disable
        internal ReplyInlineMarkup()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkrows = writer.WriteVector(Rows, false);
            if (checkrows.IsError)
            {
                return checkrows;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryrows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrows.IsError)
            {
                return ReadResult<IObject>.Move(tryrows);
            }
            Rows = tryrows.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "replyInlineMarkup";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ReplyInlineMarkup
            {
                Rows = new List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>()
            };
            foreach (var rows in Rows)
            {
                var clonerows = (CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase?)rows.Clone();
                if (clonerows is null)
                {
                    return null;
                }
                newClonedObject.Rows.Add(clonerows);
            }
            return newClonedObject;

        }
#nullable disable
    }
}