using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateReadChannelInbox : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -1842450928;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("still_unread_count")]
        public int StillUnreadCount { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }


    #nullable enable
        public UpdateReadChannelInbox(long channelId, int maxId, int stillUnreadCount, int pts)
        {
            ChannelId = channelId;
            MaxId = maxId;
            StillUnreadCount = stillUnreadCount;
            Pts = pts;
        }
    #nullable disable
        internal UpdateReadChannelInbox()
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

            writer.Write(ChannelId);
            writer.Write(MaxId);
            writer.Write(StillUnreadCount);
            writer.Write(Pts);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                FolderId = reader.Read<int>();
            }

            ChannelId = reader.Read<long>();
            MaxId = reader.Read<int>();
            StillUnreadCount = reader.Read<int>();
            Pts = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updateReadChannelInbox";
        }
    }
}