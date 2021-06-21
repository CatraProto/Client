using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SendMedia : IMethod
    {
        public static int ConstructorId { get; } = 881978281;
        public int Flags { get; set; }
        public bool Silent { get; set; }
        public bool Background { get; set; }
        public bool ClearDraft { get; set; }
        public InputPeerBase Peer { get; set; }
        public int? ReplyToMsgId { get; set; }
        public InputMediaBase Media { get; set; }
        public string Message { get; set; }
        public long RandomId { get; set; }
        public ReplyMarkupBase ReplyMarkup { get; set; }
        public IList<MessageEntityBase> Entities { get; set; }
        public int? ScheduleDate { get; set; }

        public Type Type { get; init; } = typeof(UpdatesBase);
        public bool IsVector { get; init; } = false;

        [Flags]
        public enum FlagsEnum
        {
            Silent = 1 << 5,
            Background = 1 << 6,
            ClearDraft = 1 << 7,
            ReplyToMsgId = 1 << 0,
            ReplyMarkup = 1 << 2,
            Entities = 1 << 3,
            ScheduleDate = 1 << 10
        }

        public void UpdateFlags()
        {
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = ClearDraft ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(ReplyToMsgId.Value);
            }

            writer.Write(Media);
            writer.Write(Message);
            writer.Write(RandomId);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ReplyMarkup);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Entities);
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.Write(ScheduleDate.Value);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Silent = FlagsHelper.IsFlagSet(Flags, 5);
            Background = FlagsHelper.IsFlagSet(Flags, 6);
            ClearDraft = FlagsHelper.IsFlagSet(Flags, 7);
            Peer = reader.Read<InputPeerBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                ReplyToMsgId = reader.Read<int>();
            }

            Media = reader.Read<InputMediaBase>();
            Message = reader.Read<string>();
            RandomId = reader.Read<long>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ReplyMarkup = reader.Read<ReplyMarkupBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Entities = reader.ReadVector<MessageEntityBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                ScheduleDate = reader.Read<int>();
            }
        }
    }
}