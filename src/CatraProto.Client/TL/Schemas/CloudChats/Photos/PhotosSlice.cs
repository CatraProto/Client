using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public partial class PhotosSlice : CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase
    {
        public static int StaticConstructorId
        {
            get => 352657236;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("photos")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public PhotosSlice(int count, IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> photos, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Count);
            writer.Write(Photos);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            Photos = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "photos.photosSlice";
        }
    }
}