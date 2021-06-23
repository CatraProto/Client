using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class SetContentSettings : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            SensitiveEnabled = 1 << 0
        }

        public static int ConstructorId { get; } = -1250643605;

        public Type Type { get; init; } = typeof(bool);
        public bool IsVector { get; init; } = false;
        public int Flags { get; set; }
        public bool SensitiveEnabled { get; set; }

        public void UpdateFlags()
        {
            Flags = SensitiveEnabled ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            SensitiveEnabled = FlagsHelper.IsFlagSet(Flags, 0);
        }
    }
}