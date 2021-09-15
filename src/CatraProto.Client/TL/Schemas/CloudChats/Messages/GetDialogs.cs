using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Newtonsoft.Json;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetDialogs : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ExcludePinned = 1 << 0,
            FolderId = 1 << 1
        }

        [JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1594999949;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(DialogsBase);

        [JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("exclude_pinned")] public bool ExcludePinned { get; set; }

        [JsonProperty("folder_id")] public int? FolderId { get; set; }

        [JsonProperty("offset_date")] public int OffsetDate { get; set; }

        [JsonProperty("offset_id")] public int OffsetId { get; set; }

        [JsonProperty("offset_peer")] public InputPeerBase OffsetPeer { get; set; }

        [JsonProperty("limit")] public int Limit { get; set; }

        [JsonProperty("hash")] public int Hash { get; set; }

        public override string ToString()
        {
            return "messages.getDialogs";
        }


        public void UpdateFlags()
        {
            Flags = ExcludePinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(FolderId.Value);
            }

            writer.Write(OffsetDate);
            writer.Write(OffsetId);
            writer.Write(OffsetPeer);
            writer.Write(Limit);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            ExcludePinned = FlagsHelper.IsFlagSet(Flags, 0);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                FolderId = reader.Read<int>();
            }

            OffsetDate = reader.Read<int>();
            OffsetId = reader.Read<int>();
            OffsetPeer = reader.Read<InputPeerBase>();
            Limit = reader.Read<int>();
            Hash = reader.Read<int>();
        }
    }
}