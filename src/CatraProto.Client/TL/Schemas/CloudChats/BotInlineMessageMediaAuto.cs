using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BotInlineMessageMediaAuto : BotInlineMessageBase
    {
        public static int ConstructorId { get; } = 1984755728;
        public int Flags { get; set; }
        public string Message { get; set; }
        public IList<MessageEntityBase> Entities { get; set; }
        public override ReplyMarkupBase ReplyMarkup { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Entities = 1 << 1,
            ReplyMarkup = 1 << 2
        }

        public override void UpdateFlags()
        {
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Message);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Entities);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ReplyMarkup);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Message = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Entities = reader.ReadVector<MessageEntityBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ReplyMarkup = reader.Read<ReplyMarkupBase>();
            }
        }
    }
}