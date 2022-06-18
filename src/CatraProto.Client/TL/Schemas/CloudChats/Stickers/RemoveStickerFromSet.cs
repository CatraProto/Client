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

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class RemoveStickerFromSet : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -143257775; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("sticker")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Sticker { get; set; }


#nullable enable
        public RemoveStickerFromSet(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker)
        {
            Sticker = sticker;

        }
#nullable disable

        internal RemoveStickerFromSet()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checksticker = writer.WriteObject(Sticker);
            if (checksticker.IsError)
            {
                return checksticker;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysticker = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (trysticker.IsError)
            {
                return ReadResult<IObject>.Move(trysticker);
            }
            Sticker = trysticker.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickers.removeStickerFromSet";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RemoveStickerFromSet();
            var cloneSticker = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Sticker.Clone();
            if (cloneSticker is null)
            {
                return null;
            }
            newClonedObject.Sticker = cloneSticker;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not RemoveStickerFromSet castedOther)
            {
                return true;
            }
            if (Sticker.Compare(castedOther.Sticker))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}