using System;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public class GetLeftChannels : IMethod
    {
        public static int ConstructorId { get; } = -2092831552;

        public Type Type { get; init; } = typeof(ChatsBase);
        public bool IsVector { get; init; } = false;
        public int Offset { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Offset);
        }

        public void Deserialize(Reader reader)
        {
            Offset = reader.Read<int>();
        }
    }
}