using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
    public class FileUnknown : FileTypeBase
    {
        public static int ConstructorId { get; } = -1432995067;

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }
        }

        public override void Deserialize(Reader reader)
        {
        }
    }
}