using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputBotInlineMessageGame : InputBotInlineMessageBase
    {
        public static int ConstructorId { get; } = 1262639204;
        public int Flags { get; set; }
        public override ReplyMarkupBase ReplyMarkup { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            ReplyMarkup = 1 << 2
        }

        public override void UpdateFlags()
        {
            Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ReplyMarkup);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ReplyMarkup = reader.Read<ReplyMarkupBase>();
            }
        }
    }
}