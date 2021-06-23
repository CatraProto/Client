using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public class ReadMessageContents : IMethod
    {
        public static int ConstructorId { get; } = -357180360;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public InputChannelBase Channel { get; set; }
        public IList<int> Id { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

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