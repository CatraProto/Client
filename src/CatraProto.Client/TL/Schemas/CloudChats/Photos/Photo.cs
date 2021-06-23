using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public class Photo : PhotoBase
    {
        public static int ConstructorId { get; } = 539045032;
        public override CloudChats.PhotoBase Photo_ { get; set; }
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

            writer.Write(Photo_);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Photo_ = reader.Read<CloudChats.PhotoBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}