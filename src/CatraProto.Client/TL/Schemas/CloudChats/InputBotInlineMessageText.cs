using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputBotInlineMessageText : InputBotInlineMessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            NoWebpage = 1 << 0,
            Entities = 1 << 1,
            ReplyMarkup = 1 << 2
        }

        public static int ConstructorId { get; } = 1036876423;
        public int Flags { get; set; }
        public bool NoWebpage { get; set; }
        public string Message { get; set; }
        public IList<MessageEntityBase> Entities { get; set; }
        public override ReplyMarkupBase ReplyMarkup { get; set; }

        public override void UpdateFlags()
        {
            Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
            NoWebpage = FlagsHelper.IsFlagSet(Flags, 0);
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