using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdatePinnedChannelMessages : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pinned = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 1538885128;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public IList<int> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }


    #nullable enable
        public UpdatePinnedChannelMessages(long channelId, IList<int> messages, int pts, int ptsCount)
        {
            ChannelId = channelId;
            Messages = messages;
            Pts = pts;
            PtsCount = ptsCount;
        }
    #nullable disable
        internal UpdatePinnedChannelMessages()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pinned ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(ChannelId);
            writer.Write(Messages);
            writer.Write(Pts);
            writer.Write(PtsCount);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Pinned = FlagsHelper.IsFlagSet(Flags, 0);
            ChannelId = reader.Read<long>();
            Messages = reader.ReadVector<int>();
            Pts = reader.Read<int>();
            PtsCount = reader.Read<int>();
        }

        public override string ToString()
        {
            return "updatePinnedChannelMessages";
        }
    }
}