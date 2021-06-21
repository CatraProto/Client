using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputKeyboardButtonUrlAuth : KeyboardButtonBase
    {
        public static int ConstructorId { get; } = -802258988;
        public int Flags { get; set; }
        public bool RequestWriteAccess { get; set; }
        public override string Text { get; set; }
        public string FwdText { get; set; }
        public string Url { get; set; }
        public InputUserBase Bot { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            RequestWriteAccess = 1 << 0,
            FwdText = 1 << 1
        }

        public override void UpdateFlags()
        {
            Flags = RequestWriteAccess ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = FwdText == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Text);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(FwdText);
            }

            writer.Write(Url);
            writer.Write(Bot);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            RequestWriteAccess = FlagsHelper.IsFlagSet(Flags, 0);
            Text = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                FwdText = reader.Read<string>();
            }

            Url = reader.Read<string>();
            Bot = reader.Read<InputUserBase>();
        }
    }
}