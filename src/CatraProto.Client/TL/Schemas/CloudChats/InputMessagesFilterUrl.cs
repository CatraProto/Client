using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputMessagesFilterUrl : MessagesFilterBase
    {
        public static int ConstructorId { get; } = 2129714567;

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