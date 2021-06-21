using System;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class DeleteUserHistory : IMethod
    {
        public static int ConstructorId { get; } = -787622117;
        public InputChannelBase Channel { get; set; }
        public InputUserBase UserId { get; set; }

        public Type Type { get; init; } = typeof(AffectedHistoryBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            writer.Write(Channel);
            writer.Write(UserId);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            UserId = reader.Read<InputUserBase>();
        }
    }
}