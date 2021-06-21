using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class DeepLinkInfo : DeepLinkInfoBase
    {
        public static int ConstructorId { get; } = 1783556146;
        public int Flags { get; set; }
        public bool UpdateApp { get; set; }
        public string Message { get; set; }
        public IList<MessageEntityBase> Entities { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            UpdateApp = 1 << 0,
            Entities = 1 << 1
        }

        public override void UpdateFlags()
        {
            Flags = UpdateApp ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
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
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            UpdateApp = FlagsHelper.IsFlagSet(Flags, 0);
            Message = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Entities = reader.ReadVector<MessageEntityBase>();
            }
        }
    }
}