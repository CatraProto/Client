using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public class GetChannels : IMethod
    {
        public static int ConstructorId { get; } = 176122811;

        public Type Type { get; init; } = typeof(ChatsBase);
        public bool IsVector { get; init; } = false;
        public IList<InputChannelBase> Id { get; set; }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.ReadVector<InputChannelBase>();
        }
    }
}