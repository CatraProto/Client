using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateChannelUserTyping : UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            TopMsgId = 1 << 0
        }

        public static int ConstructorId { get; } = -13975905;
        public int Flags { get; set; }
        public int ChannelId { get; set; }
        public int? TopMsgId { get; set; }
        public int UserId { get; set; }
        public SendMessageActionBase Action { get; set; }

        public override void UpdateFlags()
        {
            Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ChannelId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(TopMsgId.Value);
            }

            writer.Write(UserId);
            writer.Write(Action);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ChannelId = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                TopMsgId = reader.Read<int>();
            }

            UserId = reader.Read<int>();
            Action = reader.Read<SendMessageActionBase>();
        }
    }
}