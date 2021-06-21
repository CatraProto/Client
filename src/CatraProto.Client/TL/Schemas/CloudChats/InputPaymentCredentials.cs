using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPaymentCredentials : InputPaymentCredentialsBase
    {
        public static int ConstructorId { get; } = 873977640;
        public int Flags { get; set; }
        public bool Save { get; set; }
        public DataJSONBase Data { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Save = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = Save ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Data);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Save = FlagsHelper.IsFlagSet(Flags, 0);
            Data = reader.Read<DataJSONBase>();
        }
    }
}