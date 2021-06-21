using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ReadHistory : IMethod
    {
        public static int ConstructorId { get; } = -871347913;
        public InputChannelBase Channel { get; set; }
        public int MaxId { get; set; }

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Channel);
            writer.Write(MaxId);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            MaxId = reader.Read<int>();
        }
    }
}