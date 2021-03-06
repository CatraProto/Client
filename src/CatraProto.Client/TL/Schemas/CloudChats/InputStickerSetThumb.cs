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
    public partial class InputStickerSetThumb : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1652231205; }

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("thumb_version")]
        public int ThumbVersion { get; set; }


#nullable enable
        public InputStickerSetThumb(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, int thumbVersion)
        {
            Stickerset = stickerset;
            ThumbVersion = thumbVersion;

        }
#nullable disable
        internal InputStickerSetThumb()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }
            writer.WriteInt32(ThumbVersion);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }
            Stickerset = trystickerset.Value;
            var trythumbVersion = reader.ReadInt32();
            if (trythumbVersion.IsError)
            {
                return ReadResult<IObject>.Move(trythumbVersion);
            }
            ThumbVersion = trythumbVersion.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputStickerSetThumb";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickerSetThumb();
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }
            newClonedObject.Stickerset = cloneStickerset;
            newClonedObject.ThumbVersion = ThumbVersion;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputStickerSetThumb castedOther)
            {
                return true;
            }
            if (Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }
            if (ThumbVersion != castedOther.ThumbVersion)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}