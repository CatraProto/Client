using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public class EditBanned : IMethod
    {
        public static int ConstructorId { get; } = 1920559378;

        public Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;
        public InputChannelBase Channel { get; set; }
        public InputUserBase UserId { get; set; }
        public ChatBannedRightsBase BannedRights { get; set; }

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
            writer.Write(UserId);
            writer.Write(BannedRights);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            UserId = reader.Read<InputUserBase>();
            BannedRights = reader.Read<ChatBannedRightsBase>();
        }
    }
}