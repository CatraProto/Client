using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class UpdateReadChannelDiscussionInbox : UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            BroadcastId = 1 << 0,
            BroadcastPost = 1 << 0
        }

        public static int ConstructorId { get; } = 482860628;
        public int Flags { get; set; }
        public int ChannelId { get; set; }
        public int TopMsgId { get; set; }
        public int ReadMaxId { get; set; }
        public int? BroadcastId { get; set; }
        public int? BroadcastPost { get; set; }

        public override void UpdateFlags()
        {
            Flags = BroadcastId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = BroadcastPost == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ChannelId);
            writer.Write(TopMsgId);
            writer.Write(ReadMaxId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(BroadcastId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(BroadcastPost.Value);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ChannelId = reader.Read<int>();
            TopMsgId = reader.Read<int>();
            ReadMaxId = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                BroadcastId = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                BroadcastPost = reader.Read<int>();
            }
        }
    }
}