using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class Search : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            FromId = 1 << 0,
            TopMsgId = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1593989278;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("q")] public string Q { get; set; }

        [Newtonsoft.Json.JsonProperty("from_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase FromId { get; set; }

        [Newtonsoft.Json.JsonProperty("top_msg_id")]
        public int? TopMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("min_date")]
        public int MinDate { get; set; }

        [Newtonsoft.Json.JsonProperty("max_date")]
        public int MaxDate { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id")]
        public int OffsetId { get; set; }

        [Newtonsoft.Json.JsonProperty("add_offset")]
        public int AddOffset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("min_id")]
        public int MinId { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }


    #nullable enable
        public Search(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetId, int addOffset, int limit, int maxId, int minId, long hash)
        {
            Peer = peer;
            Q = q;
            Filter = filter;
            MinDate = minDate;
            MaxDate = maxDate;
            OffsetId = offsetId;
            AddOffset = addOffset;
            Limit = limit;
            MaxId = maxId;
            MinId = minId;
            Hash = hash;
        }
    #nullable disable

        internal Search()
        {
        }

        public void UpdateFlags()
        {
            Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = TopMsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            writer.Write(Q);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(FromId);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(TopMsgId.Value);
            }

            writer.Write(Filter);
            writer.Write(MinDate);
            writer.Write(MaxDate);
            writer.Write(OffsetId);
            writer.Write(AddOffset);
            writer.Write(Limit);
            writer.Write(MaxId);
            writer.Write(MinId);
            writer.Write(Hash);
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            Q = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                FromId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                TopMsgId = reader.Read<int>();
            }

            Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
            MinDate = reader.Read<int>();
            MaxDate = reader.Read<int>();
            OffsetId = reader.Read<int>();
            AddOffset = reader.Read<int>();
            Limit = reader.Read<int>();
            MaxId = reader.Read<int>();
            MinId = reader.Read<int>();
            Hash = reader.Read<long>();
        }

        public override string ToString()
        {
            return "messages.search";
        }
    }
}