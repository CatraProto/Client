using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetChannels : IMethod<ChatsBase>
    {
        public static int ConstructorId { get; } = 176122811;
        public IList<InputChannelBase> Id { get; set; }

        public Type Type { get; init; } = typeof(GetChannels);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Id = reader.ReadVector<InputChannelBase>();
        }
    }
}