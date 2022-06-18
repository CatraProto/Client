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
    public partial class DocumentAttributeFilename : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 358154344; }

        [Newtonsoft.Json.JsonProperty("file_name")]
        public string FileName { get; set; }


#nullable enable
        public DocumentAttributeFilename(string fileName)
        {
            FileName = fileName;

        }
#nullable disable
        internal DocumentAttributeFilename()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(FileName);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfileName = reader.ReadString();
            if (tryfileName.IsError)
            {
                return ReadResult<IObject>.Move(tryfileName);
            }
            FileName = tryfileName.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "documentAttributeFilename";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DocumentAttributeFilename
            {
                FileName = FileName
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not DocumentAttributeFilename castedOther)
            {
                return true;
            }
            if (FileName != castedOther.FileName)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}