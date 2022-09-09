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
    public partial class PhotosSlice : CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 352657236; }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("photos")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public PhotosSlice(int count, List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> photos, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            Photos = photos;
            Users = users;
        }
#nullable disable
        internal PhotosSlice()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checkphotos = writer.WriteVector(Photos, false);
            if (checkphotos.IsError)
            {
                return checkphotos;
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
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            var tryphotos = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryphotos.IsError)
            {
                return ReadResult<IObject>.Move(tryphotos);
            }

            Photos = tryphotos.Value;
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
            return "photos.photosSlice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhotosSlice();
            newClonedObject.Count = Count;
            newClonedObject.Photos = new List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            foreach (var photos in Photos)
            {
                var clonephotos = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)photos.Clone();
                if (clonephotos is null)
                {
                    return null;
                }

                newClonedObject.Photos.Add(clonephotos);
            }

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
            if (other is not PhotosSlice castedOther)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            var photossize = castedOther.Photos.Count;
            if (photossize != Photos.Count)
            {
                return true;
            }

            for (var i = 0; i < photossize; i++)
            {
                if (castedOther.Photos[i].Compare(Photos[i]))
                {
                    return true;
                }
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