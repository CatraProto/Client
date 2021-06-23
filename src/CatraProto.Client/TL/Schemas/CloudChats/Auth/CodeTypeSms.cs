using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public class CodeTypeSms : CodeTypeBase
    {
        public static int ConstructorId { get; } = 1923290508;

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