using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public partial class LoadAsyncGraph : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            X = 1 << 0
        }

        public static int ConstructorId { get; } = 1646092192;
        public int Flags { get; set; }
        public string Token { get; set; }
        public long? X { get; set; }

        public Type Type { get; init; } = typeof(StatsGraphBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
            Flags = X == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Token);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(X.Value);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Token = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                X = reader.Read<long>();
            }
        }
    }
}