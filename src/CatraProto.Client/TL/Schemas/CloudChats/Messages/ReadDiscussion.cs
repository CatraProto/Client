using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReadDiscussion : IMethod
    {
        public static int ConstructorId { get; } = -147740172;
        public InputPeerBase Peer { get; set; }
        public int MsgId { get; set; }
        public int ReadMaxId { get; set; }

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(MsgId);
            writer.Write(ReadMaxId);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputPeerBase>();
            MsgId = reader.Read<int>();
            ReadMaxId = reader.Read<int>();
        }
    }
}