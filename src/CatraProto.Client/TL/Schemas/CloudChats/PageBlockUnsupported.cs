using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PageBlockUnsupported : PageBlockBase
    {
        public static int ConstructorId { get; } = 324435594;

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