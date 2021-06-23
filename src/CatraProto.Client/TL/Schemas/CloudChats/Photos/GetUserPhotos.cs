using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public class GetUserPhotos : IMethod
    {
        public static int ConstructorId { get; } = -1848823128;

        public System.Type Type { get; init; } = typeof(PhotosBase);
        public bool IsVector { get; init; } = false;
        public InputUserBase UserId { get; set; }
        public int Offset { get; set; }
        public long MaxId { get; set; }
        public int Limit { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(UserId);
            writer.Write(Offset);
            writer.Write(MaxId);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            UserId = reader.Read<InputUserBase>();
            Offset = reader.Read<int>();
            MaxId = reader.Read<long>();
            Limit = reader.Read<int>();
        }
    }
}