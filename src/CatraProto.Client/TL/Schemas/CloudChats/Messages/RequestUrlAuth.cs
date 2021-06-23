using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class RequestUrlAuth : IMethod
    {
        public static int ConstructorId { get; } = -482388461;

        public System.Type Type { get; init; } = typeof(UrlAuthResultBase);
        public bool IsVector { get; init; } = false;
        public InputPeerBase Peer { get; set; }
        public int MsgId { get; set; }
        public int ButtonId { get; set; }

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
            writer.Write(MsgId);
            writer.Write(ButtonId);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            MsgId = reader.Read<int>();
            ButtonId = reader.Read<int>();
        }
    }
}