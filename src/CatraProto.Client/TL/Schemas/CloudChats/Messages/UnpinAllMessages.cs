using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class UnpinAllMessages : IMethod
    {
        public static int ConstructorId { get; } = -265962357;

        public System.Type Type { get; init; } = typeof(AffectedHistoryBase);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Peer { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Peer);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
        }
    }
}