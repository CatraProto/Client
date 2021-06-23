using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public class PollAnswerVoters : PollAnswerVotersBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Chosen = 1 << 0,
            Correct = 1 << 1
        }

        public static int ConstructorId { get; } = 997055186;
        public int Flags { get; set; }
        public override bool Chosen { get; set; }
        public override bool Correct { get; set; }
        public override byte[] Option { get; set; }
        public override int Voters { get; set; }

        public override void UpdateFlags()
        {
            Flags = Chosen ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Correct ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Option);
            writer.Write(Voters);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Chosen = FlagsHelper.IsFlagSet(Flags, 0);
            Correct = FlagsHelper.IsFlagSet(Flags, 1);
            Option = reader.Read<byte[]>();
            Voters = reader.Read<int>();
        }
    }
}