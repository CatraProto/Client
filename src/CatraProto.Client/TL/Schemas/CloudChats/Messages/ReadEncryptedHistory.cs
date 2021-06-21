using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReadEncryptedHistory : IMethod
    {
        public static int ConstructorId { get; } = 2135648522;
        public InputEncryptedChatBase Peer { get; set; }
        public int MaxDate { get; set; }

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(MaxDate);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<InputEncryptedChatBase>();
            MaxDate = reader.Read<int>();
        }
    }
}