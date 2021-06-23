using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public class ChannelMessages : MessagesBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Inexact = 1 << 1,
            OffsetIdOffset = 1 << 2
        }

        public static int ConstructorId { get; } = 1682413576;
        public int Flags { get; set; }
        public bool Inexact { get; set; }
        public int Pts { get; set; }
        public int Count { get; set; }
        public int? OffsetIdOffset { get; set; }
        public IList<MessageBase> Messages { get; set; }
        public IList<ChatBase> Chats { get; set; }
        public IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
            Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = OffsetIdOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Pts);
            writer.Write(Count);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(OffsetIdOffset.Value);
            }

            writer.Write(Messages);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Inexact = FlagsHelper.IsFlagSet(Flags, 1);
            Pts = reader.Read<int>();
            Count = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                OffsetIdOffset = reader.Read<int>();
            }

            Messages = reader.ReadVector<MessageBase>();
            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}