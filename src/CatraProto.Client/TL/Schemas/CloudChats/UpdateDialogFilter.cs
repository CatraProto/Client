using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDialogFilter : UpdateBase
    {
        public static int ConstructorId { get; } = 654302845;
        public int Flags { get; set; }
        public int Id { get; set; }
        public DialogFilterBase Filter { get; set; }

        [Flags]
        public enum FlagsEnum
        {
            Filter = 1 << 0
        }

        public override void UpdateFlags()
        {
            Flags = Filter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Filter);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Id = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Filter = reader.Read<DialogFilterBase>();
            }
        }
    }
}