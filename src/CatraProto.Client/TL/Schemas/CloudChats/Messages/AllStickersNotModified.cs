using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class AllStickersNotModified : AllStickersBase
    {
        public static int ConstructorId { get; } = -395967805;

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