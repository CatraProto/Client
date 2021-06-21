using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class RecentStickersNotModified : RecentStickersBase
    {
        public static int ConstructorId { get; } = 186120336;

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