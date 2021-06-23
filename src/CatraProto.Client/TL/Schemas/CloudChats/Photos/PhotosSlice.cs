using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public class PhotosSlice : PhotosBase
    {
        public static int ConstructorId { get; } = 352657236;
        public int Count { get; set; }
        public override IList<CloudChats.PhotoBase> Photos { get; set; }
        public override IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Count);
            writer.Write(Photos);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
            Photos = reader.ReadVector<CloudChats.PhotoBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}