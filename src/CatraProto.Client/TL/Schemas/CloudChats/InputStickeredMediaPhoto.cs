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
    public partial class InputStickeredMediaPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1251549527; }

        [Newtonsoft.Json.JsonProperty("id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Id { get; set; }


#nullable enable
        public InputStickeredMediaPhoto(CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase id)
        {
            Id = id;

        }
#nullable disable
        internal InputStickeredMediaPhoto()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputStickeredMediaPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickeredMediaPhoto();
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }
            newClonedObject.Id = cloneId;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputStickeredMediaPhoto castedOther)
            {
                return true;
            }
            if (Id.Compare(castedOther.Id))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}