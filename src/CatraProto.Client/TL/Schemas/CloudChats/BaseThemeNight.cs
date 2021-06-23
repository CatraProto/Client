using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class BaseThemeNight : BaseThemeBase
    {
        public static int ConstructorId { get; } = -1212997976;

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