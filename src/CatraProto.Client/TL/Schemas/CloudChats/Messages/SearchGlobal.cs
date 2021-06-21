using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SearchGlobal : IMethod
    {
        public static int ConstructorId { get; } = 1271290010;
        public int Flags { get; set; }
        public int? FolderId { get; set; }
        public string Q { get; set; }
        public MessagesFilterBase Filter { get; set; }
        public int MinDate { get; set; }
        public int MaxDate { get; set; }
        public int OffsetRate { get; set; }
        public InputPeerBase OffsetPeer { get; set; }
        public int OffsetId { get; set; }
        public int Limit { get; set; }

        public Type Type { get; init; } = typeof(MessagesBase);
        public bool IsVector { get; init; } = false;

        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 0
        }

        public void UpdateFlags()
        {
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0) writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(FolderId.Value);
            }

            writer.Write(Q);
            writer.Write(Filter);
            writer.Write(MinDate);
            writer.Write(MaxDate);
            writer.Write(OffsetRate);
            writer.Write(OffsetPeer);
            writer.Write(OffsetId);
            writer.Write(Limit);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                FolderId = reader.Read<int>();
            }

            Q = reader.Read<string>();
            Filter = reader.Read<MessagesFilterBase>();
            MinDate = reader.Read<int>();
            MaxDate = reader.Read<int>();
            OffsetRate = reader.Read<int>();
            OffsetPeer = reader.Read<InputPeerBase>();
            OffsetId = reader.Read<int>();
            Limit = reader.Read<int>();
        }
    }
}