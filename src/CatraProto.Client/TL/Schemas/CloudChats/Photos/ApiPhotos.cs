using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public partial class ApiPhotos : CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1916114267; }

        [Newtonsoft.Json.JsonProperty("photos")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ApiPhotos(List<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> photos, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Photos = photos;
            Users = users;

        }
#nullable disable
        internal ApiPhotos()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
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
            return "photos.photos";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ApiPhotos();
            foreach (var photos in Photos)
            {
                var clonephotos = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)photos.Clone();
                if (clonephotos is null)
                {
                    return null;
                }
                newClonedObject.Photos.Add(clonephotos);
            }
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
#nullable disable
    }
}