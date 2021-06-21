using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DeleteHistory : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            JustClear = 1 << 0,
            Revoke = 1 << 1
        }

        public static int ConstructorId { get; } = 469850889;
        public int Flags { get; set; }
        public bool JustClear { get; set; }
        public bool Revoke { get; set; }
        public InputPeerBase Peer { get; set; }
        public int MaxId { get; set; }

        public Type Type { get; init; } = typeof(AffectedHistoryBase);
        public bool IsVector { get; init; } = false;

        public void UpdateFlags()
        {
            Flags = JustClear ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Revoke ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            writer.Write(MaxId);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            JustClear = FlagsHelper.IsFlagSet(Flags, 0);
            Revoke = FlagsHelper.IsFlagSet(Flags, 1);
            Peer = reader.Read<InputPeerBase>();
            MaxId = reader.Read<int>();
        }
    }
}