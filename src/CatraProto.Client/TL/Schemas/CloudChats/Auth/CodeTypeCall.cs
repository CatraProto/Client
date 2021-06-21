using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class CodeTypeCall : CodeTypeBase
    {
        public static int ConstructorId { get; } = 1948046307;

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