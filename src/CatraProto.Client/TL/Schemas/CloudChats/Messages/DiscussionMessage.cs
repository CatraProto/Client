using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DiscussionMessage : CatraProto.Client.TL.Schemas.CloudChats.Messages.DiscussionMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            MaxId = 1 << 0,
            ReadInboxMaxId = 1 << 1,
            ReadOutboxMaxId = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => -1506535550;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public sealed override int? MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_inbox_max_id")]
        public sealed override int? ReadInboxMaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_outbox_max_id")]
        public sealed override int? ReadOutboxMaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_count")]
        public sealed override int UnreadCount { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public DiscussionMessage(IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages, int unreadCount, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Messages = messages;
            UnreadCount = unreadCount;
            Chats = chats;
            Users = users;
        }
    #nullable disable
        internal DiscussionMessage()
        {
        }

        public override void UpdateFlags()
        {
            Flags = MaxId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ReadInboxMaxId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ReadOutboxMaxId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
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

            writer.Write(UnreadCount);
            writer.Write(Chats);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
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

            UnreadCount = reader.Read<int>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "messages.discussionMessage";
        }
    }
}