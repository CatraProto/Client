using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class MessageFwdHeader : MessageFwdHeaderBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Imported = 1 << 7,
            FromId = 1 << 0,
            FromName = 1 << 5,
            ChannelPost = 1 << 2,
            PostAuthor = 1 << 3,
            SavedFromPeer = 1 << 4,
            SavedFromMsgId = 1 << 4,
            PsaType = 1 << 6
        }

        public static int ConstructorId { get; } = 1601666510;
        public int Flags { get; set; }
        public override bool Imported { get; set; }
        public override PeerBase FromId { get; set; }
        public override string FromName { get; set; }
        public override int Date { get; set; }
        public override int? ChannelPost { get; set; }
        public override string PostAuthor { get; set; }
        public override PeerBase SavedFromPeer { get; set; }
        public override int? SavedFromMsgId { get; set; }
        public override string PsaType { get; set; }

        public override void UpdateFlags()
        {
            Flags = Imported ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = FromName == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
            Flags = ChannelPost == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = PostAuthor == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = SavedFromPeer == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = SavedFromMsgId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = PsaType == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(FromId);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.Write(FromName);
            }

            writer.Write(Date);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ChannelPost.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(PostAuthor);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(SavedFromPeer);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(SavedFromMsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.Write(PsaType);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Imported = FlagsHelper.IsFlagSet(Flags, 7);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                FromId = reader.Read<PeerBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                FromName = reader.Read<string>();
            }

            Date = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ChannelPost = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                PostAuthor = reader.Read<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                SavedFromPeer = reader.Read<PeerBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                SavedFromMsgId = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                PsaType = reader.Read<string>();
            }
        }
    }
}