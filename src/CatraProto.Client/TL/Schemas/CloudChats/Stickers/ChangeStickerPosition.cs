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
    public partial class ChangeStickerPosition : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -4795190; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("sticker")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Sticker { get; set; }

        [Newtonsoft.Json.JsonProperty("position")]
        public int Position { get; set; }


#nullable enable
        public ChangeStickerPosition(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker, int position)
        {
            Sticker = sticker;
            Position = position;

        }
#nullable disable

        internal ChangeStickerPosition()
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
            writer.WriteInt32(Position);

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
            var tryposition = reader.ReadInt32();
            if (tryposition.IsError)
            {
                return ReadResult<IObject>.Move(tryposition);
            }
            Position = tryposition.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickers.changeStickerPosition";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ChangeStickerPosition();
            var cloneSticker = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Sticker.Clone();
            if (cloneSticker is null)
            {
                return null;
            }
            newClonedObject.Sticker = cloneSticker;
            newClonedObject.Position = Position;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not ChangeStickerPosition castedOther)
            {
                return true;
            }
            if (Sticker.Compare(castedOther.Sticker))
            {
                return true;
            }
            if (Position != castedOther.Position)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}