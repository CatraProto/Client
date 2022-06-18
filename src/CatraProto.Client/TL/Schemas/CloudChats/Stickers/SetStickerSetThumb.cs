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
    public partial class SetStickerSetThumb : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1707717072; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Thumb { get; set; }


#nullable enable
        public SetStickerSetThumb(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase thumb)
        {
            Stickerset = stickerset;
            Thumb = thumb;

        }
#nullable disable

        internal SetStickerSetThumb()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }
            var checkthumb = writer.WriteObject(Thumb);
            if (checkthumb.IsError)
            {
                return checkthumb;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }
            Stickerset = trystickerset.Value;
            var trythumb = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (trythumb.IsError)
            {
                return ReadResult<IObject>.Move(trythumb);
            }
            Thumb = trythumb.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickers.setStickerSetThumb";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetStickerSetThumb();
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }
            newClonedObject.Stickerset = cloneStickerset;
            var cloneThumb = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Thumb.Clone();
            if (cloneThumb is null)
            {
                return null;
            }
            newClonedObject.Thumb = cloneThumb;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not SetStickerSetThumb castedOther)
            {
                return true;
            }
            if (Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }
            if (Thumb.Compare(castedOther.Thumb))
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}