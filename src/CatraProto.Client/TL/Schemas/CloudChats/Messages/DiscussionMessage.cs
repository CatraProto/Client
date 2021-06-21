using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DiscussionMessage : DiscussionMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            MaxId = 1 << 0,
            ReadInboxMaxId = 1 << 1,
            ReadOutboxMaxId = 1 << 2
        }

        public static int ConstructorId { get; } = -170029155;
        public int Flags { get; set; }
        public override IList<MessageBase> Messages { get; set; }
        public override int? MaxId { get; set; }
        public override int? ReadInboxMaxId { get; set; }
        public override int? ReadOutboxMaxId { get; set; }
        public override IList<ChatBase> Chats { get; set; }
        public override IList<UserBase> Users { get; set; }

        public override void UpdateFlags()
        {
            Flags = MaxId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ReadInboxMaxId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ReadOutboxMaxId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Messages);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(MaxId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(ReadInboxMaxId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ReadOutboxMaxId.Value);
            }

            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Messages = reader.ReadVector<MessageBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                MaxId = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                ReadInboxMaxId = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ReadOutboxMaxId = reader.Read<int>();
            }

            Chats = reader.ReadVector<ChatBase>();
            Users = reader.ReadVector<UserBase>();
        }
    }
}