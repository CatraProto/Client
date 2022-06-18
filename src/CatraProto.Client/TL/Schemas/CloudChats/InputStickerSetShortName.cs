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
    public partial class InputStickerSetShortName : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2044933984; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }


#nullable enable
        public InputStickerSetShortName(string shortName)
        {
            ShortName = shortName;

        }
#nullable disable
        internal InputStickerSetShortName()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(ShortName);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }
            ShortName = tryshortName.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputStickerSetShortName";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickerSetShortName
            {
                ShortName = ShortName
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputStickerSetShortName castedOther)
            {
                return true;
            }
            if (ShortName != castedOther.ShortName)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}