using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class InputDocumentEmpty : InputDocumentBase
    {
        public static int ConstructorId { get; } = 1928391342;

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