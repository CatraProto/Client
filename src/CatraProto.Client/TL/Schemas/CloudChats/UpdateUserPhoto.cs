using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateUserPhoto : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -232290676; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

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
            var newClonedObject = new UpdateUserPhoto();
            newClonedObject.UserId = UserId;
            newClonedObject.Date = Date;
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