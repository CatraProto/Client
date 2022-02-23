using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateReadHistoryInbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -1667805217;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("still_unread_count")]
        public int StillUnreadCount { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


    #nullable enable
        public UpdateReadHistoryInbox(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int maxId, int stillUnreadCount, int pts, int ptsCount)
        {
            Peer = peer;
            MaxId = maxId;
            StillUnreadCount = stillUnreadCount;
            Pts = pts;
            PtsCount = ptsCount;
        }
    #nullable disable
        internal UpdateReadHistoryInbox()
        {
        }

        public override void UpdateFlags()
        {
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(FolderId.Value);
            }

            writer.Write(Peer);
            writer.Write(MaxId);
            writer.Write(StillUnreadCount);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                FolderId = reader.Read<int>();
            }

            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            MaxId = reader.Read<int>();
            StillUnreadCount = reader.Read<int>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateReadHistoryInbox";
        }
    }
}