using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class ContactsNotModified : ContactsBase
    {
        public static int ConstructorId { get; } = -1219778094;

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