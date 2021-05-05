using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ToggleSignatures : IMethod<UpdatesBase>
    {
        public static int ConstructorId { get; } = 527021574;
        public InputChannelBase Channel { get; set; }
        public bool Enabled { get; set; }

        public Type Type { get; init; } = typeof(ToggleSignatures);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Channel);
            writer.Write(Enabled);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Enabled = reader.Read<bool>();
        }
    }
}