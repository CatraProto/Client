using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class GetMessagesViews : IMethod
    {
        public static int ConstructorId { get; } = 1468322785;

        public System.Type Type { get; init; } = typeof(MessageViewsBase);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Peer { get; set; }
        public IList<int> Id { get; set; }
        public bool Increment { get; set; }

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
            writer.Write(Id);
            writer.Write(Increment);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            Id = reader.ReadVector<int>();
            Increment = reader.Read<bool>();
        }
    }
}