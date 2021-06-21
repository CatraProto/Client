using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class DeleteChannel : IMethod
    {
        public static int ConstructorId { get; } = -1072619549;
        public InputChannelBase Channel { get; set; }

        public Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Channel);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
        }
    }
}