using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageReplies : CatraProto.Client.TL.Schemas.CloudChats.MessageRepliesBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Comments = 1 << 0,
            RecentRepliers = 1 << 1,
            ChannelId = 1 << 0,
            MaxId = 1 << 2,
            ReadMaxId = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2083123262; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("comments")]
        public sealed override bool Comments { get; set; }

        [Newtonsoft.Json.JsonProperty("replies")]
        public sealed override int Replies { get; set; }

        [Newtonsoft.Json.JsonProperty("replies_pts")]
        public sealed override int RepliesPts { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("recent_repliers")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> RecentRepliers { get; set; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public sealed override long? ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public sealed override int? MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_max_id")]
        public sealed override int? ReadMaxId { get; set; }


#nullable enable
        public MessageReplies(int replies, int repliesPts)
        {
            Replies = replies;
            RepliesPts = repliesPts;

        }
#nullable disable
        internal MessageReplies()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Comments ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = RecentRepliers == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ChannelId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = MaxId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = ReadMaxId == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Replies);
            writer.WriteInt32(RepliesPts);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkrecentRepliers = writer.WriteVector(RecentRepliers, false);
                if (checkrecentRepliers.IsError)
                {
                    return checkrecentRepliers;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt64(ChannelId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(MaxId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteInt32(ReadMaxId.Value);
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Comments = FlagsHelper.IsFlagSet(Flags, 0);
            var tryreplies = reader.ReadInt32();
            if (tryreplies.IsError)
            {
                return ReadResult<IObject>.Move(tryreplies);
            }
            Replies = tryreplies.Value;
            var tryrepliesPts = reader.ReadInt32();
            if (tryrepliesPts.IsError)
            {
                return ReadResult<IObject>.Move(tryrepliesPts);
            }
            RepliesPts = tryrepliesPts.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryrecentRepliers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryrecentRepliers.IsError)
                {
                    return ReadResult<IObject>.Move(tryrecentRepliers);
                }
                RecentRepliers = tryrecentRepliers.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trychannelId = reader.ReadInt64();
                if (trychannelId.IsError)
                {
                    return ReadResult<IObject>.Move(trychannelId);
                }
                ChannelId = trychannelId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trymaxId = reader.ReadInt32();
                if (trymaxId.IsError)
                {
                    return ReadResult<IObject>.Move(trymaxId);
                }
                MaxId = trymaxId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryreadMaxId = reader.ReadInt32();
                if (tryreadMaxId.IsError)
                {
                    return ReadResult<IObject>.Move(tryreadMaxId);
                }
                ReadMaxId = tryreadMaxId.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageReplies";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}