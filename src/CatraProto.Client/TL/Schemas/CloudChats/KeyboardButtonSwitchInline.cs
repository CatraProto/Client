using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class KeyboardButtonSwitchInline : KeyboardButtonBase
    {
        [Flags]
        public enum FlagsEnum
        {
            SamePeer = 1 << 0
        }

        public static int ConstructorId { get; } = 90744648;
        public int Flags { get; set; }
        public bool SamePeer { get; set; }
        public override string Text { get; set; }
        public string Query { get; set; }

        public override void UpdateFlags()
        {
            Flags = SamePeer ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Text);
            writer.Write(Query);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            SamePeer = FlagsHelper.IsFlagSet(Flags, 0);
            Text = reader.Read<string>();
            Query = reader.Read<string>();
        }
    }
}