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
    public partial class UpdateUserPhoto : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -232290676; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("previous")]
        public bool Previous { get; set; }


#nullable enable
        public UpdateUserPhoto(long userId, int date, CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase photo, bool previous)
        {
            UserId = userId;
            Date = date;
            Photo = photo;
            Previous = previous;

        }
#nullable disable
        internal UpdateUserPhoto()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt32(Date);
            var checkphoto = writer.WriteObject(Photo);
            if (checkphoto.IsError)
            {
                return checkphoto;
            }
            var checkprevious = writer.WriteBool(Previous);
            if (checkprevious.IsError)
            {
                return checkprevious;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase>();
            if (tryphoto.IsError)
            {
                return ReadResult<IObject>.Move(tryphoto);
            }
            Photo = tryphoto.Value;
            var tryprevious = reader.ReadBool();
            if (tryprevious.IsError)
            {
                return ReadResult<IObject>.Move(tryprevious);
            }
            Previous = tryprevious.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateUserPhoto";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateUserPhoto
            {
                UserId = UserId,
                Date = Date
            };
            var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.UserProfilePhotoBase?)Photo.Clone();
            if (clonePhoto is null)
            {
                return null;
            }
            newClonedObject.Photo = clonePhoto;
            newClonedObject.Previous = Previous;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateUserPhoto castedOther)
            {
                return true;
            }
            if (UserId != castedOther.UserId)
            {
                return true;
            }
            if (Date != castedOther.Date)
            {
                return true;
            }
            if (Photo.Compare(castedOther.Photo))
            {
                return true;
            }
            if (Previous != castedOther.Previous)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}