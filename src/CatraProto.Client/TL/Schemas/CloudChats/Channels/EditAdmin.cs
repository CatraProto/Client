using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public class EditAdmin : IMethod
    {
        public static int ConstructorId { get; } = -751007486;

        public Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;
        public InputChannelBase Channel { get; set; }
        public InputUserBase UserId { get; set; }
        public ChatAdminRightsBase AdminRights { get; set; }
        public string Rank { get; set; }

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
            writer.Write(AdminRights);
            writer.Write(Rank);
        }

        public void Deserialize(Reader reader)
        {
            Channel = reader.Read<InputChannelBase>();
            UserId = reader.Read<InputUserBase>();
            AdminRights = reader.Read<ChatAdminRightsBase>();
            Rank = reader.Read<string>();
        }
    }
}