using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ToggleSlowMode : IMethod
    {
        public static int ConstructorId { get; } = -304832784;
        public InputChannelBase Channel { get; set; }
        public int Seconds { get; set; }

        public Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Channel);
            writer.Write(Seconds);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Seconds = reader.Read<int>();
        }
    }
}