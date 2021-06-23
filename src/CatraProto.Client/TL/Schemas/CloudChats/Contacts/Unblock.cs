using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public class Unblock : IMethod
    {
        public static int ConstructorId { get; } = -1096393392;

        public System.Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Id { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.Read<InputPeerBase>();
        }
    }
}