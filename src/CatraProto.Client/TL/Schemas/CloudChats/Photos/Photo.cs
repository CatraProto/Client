using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public partial class Photo : CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 539045032; }

        [Newtonsoft.Json.JsonProperty("photo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase PhotoField { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public Photo(CatraProto.Client.TL.Schemas.CloudChats.PhotoBase photoField, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            PhotoField = photoField;
            Users = users;
        }
#nullable disable
        internal Photo()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkphotoField = writer.WriteObject(PhotoField);
            if (checkphotoField.IsError)
            {
                return checkphotoField;
            }

            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphotoField = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            if (tryphotoField.IsError)
            {
                return ReadResult<IObject>.Move(tryphotoField);
            }

            PhotoField = tryphotoField.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }

            Users = tryusers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "photos.photo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Photo();
            var clonePhotoField = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)PhotoField.Clone();
            if (clonePhotoField is null)
            {
                return null;
            }

            newClonedObject.PhotoField = clonePhotoField;
            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }

                newClonedObject.Users.Add(cloneusers);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Photo castedOther)
            {
                return true;
            }

            if (PhotoField.Compare(castedOther.PhotoField))
            {
                return true;
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}