using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ReadMessageContents : IMethod<bool>
    {
        public static int ConstructorId { get; } = -357180360;
        public InputChannelBase Channel { get; set; }
        public IList<int> Id { get; set; }

        public Type Type { get; init; } = typeof(ReadMessageContents);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Channel);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            Id = reader.ReadVector<int>();
        }
    }
}