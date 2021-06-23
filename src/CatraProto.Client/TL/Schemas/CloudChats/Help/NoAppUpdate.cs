using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public class NoAppUpdate : AppUpdateBase
    {
        public static int ConstructorId { get; } = -1000708810;

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