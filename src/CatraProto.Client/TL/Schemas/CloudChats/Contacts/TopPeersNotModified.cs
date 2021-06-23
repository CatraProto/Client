using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public class TopPeersNotModified : TopPeersBase
    {
        public static int ConstructorId { get; } = -567906571;

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