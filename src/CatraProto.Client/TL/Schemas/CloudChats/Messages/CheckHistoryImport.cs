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

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class CheckHistoryImport : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1140726259; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("import_head")]
        public string ImportHead { get; set; }


#nullable enable
        public CheckHistoryImport(string importHead)
        {
            ImportHead = importHead;

        }
#nullable disable

        internal CheckHistoryImport()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(ImportHead);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryimportHead = reader.ReadString();
            if (tryimportHead.IsError)
            {
                return ReadResult<IObject>.Move(tryimportHead);
            }
            ImportHead = tryimportHead.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.checkHistoryImport";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new CheckHistoryImport
            {
                ImportHead = ImportHead
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not CheckHistoryImport castedOther)
            {
                return true;
            }
            if (ImportHead != castedOther.ImportHead)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}