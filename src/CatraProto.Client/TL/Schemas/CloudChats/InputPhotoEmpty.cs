using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPhotoEmpty : InputPhotoBase
    {
        public static int ConstructorId { get; } = 483901197;

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }
    }
}