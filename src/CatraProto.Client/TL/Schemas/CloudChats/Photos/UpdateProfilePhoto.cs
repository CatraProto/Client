using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public class UpdateProfilePhoto : IMethod
    {
        public static int ConstructorId { get; } = 1926525996;

        public System.Type Type { get; init; } = typeof(PhotoBase);
        public bool IsVector { get; init; } = false;
        public InputPhotoBase Id { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputPhotoBase>();
        }
    }
}