using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public class ValidateRequestedInfo : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Save = 1 << 0
        }

        public static int ConstructorId { get; } = 1997180532;

        public System.Type Type { get; init; } = typeof(ValidatedRequestedInfoBase);
        public bool IsVector { get; init; } = false;
        public int Flags { get; set; }
        public bool Save { get; set; }
        public int MsgId { get; set; }
        public PaymentRequestedInfoBase Info { get; set; }

        public void UpdateFlags()
        {
            Flags = Save ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(MsgId);
            writer.Write(Info);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Save = FlagsHelper.IsFlagSet(Flags, 0);
            MsgId = reader.Read<int>();
            Info = reader.Read<PaymentRequestedInfoBase>();
        }
    }
}