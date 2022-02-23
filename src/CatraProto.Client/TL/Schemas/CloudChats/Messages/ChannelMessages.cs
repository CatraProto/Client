using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ChannelMessages : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Inexact = 1 << 1,
            OffsetIdOffset = 1 << 2
        }

        public static int StaticConstructorId
        {
            get => 1682413576;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("inexact")]
        public bool Inexact { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id_offset")]
        public int? OffsetIdOffset { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public ChannelMessages(int pts, int count, IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages, IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Pts = pts;
            Count = count;
            Messages = messages;
            Chats = chats;
            Users = users;
        }
    #nullable disable
        internal ChannelMessages()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = OffsetIdOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
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

            Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "messages.channelMessages";
        }
    }
}