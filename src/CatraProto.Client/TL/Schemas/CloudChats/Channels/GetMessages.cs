using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public class GetMessages : IMethod
    {
        public static int ConstructorId { get; } = -1383294429;

        public Type Type { get; init; } = typeof(MessagesBase);
        public bool IsVector { get; init; } = false;
        public InputChannelBase Channel { get; set; }
        public IList<InputMessageBase> Id { get; set; }

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
            Id = reader.ReadVector<InputMessageBase>();
        }
    }
}