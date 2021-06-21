using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
    public partial class UpdateProfilePhoto : IMethod
    {
        public static int ConstructorId { get; } = 1926525996;
        public InputPhotoBase Id { get; set; }

        public Type Type { get; init; } = typeof(PhotoBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputPhotoBase>();
        }
    }
}