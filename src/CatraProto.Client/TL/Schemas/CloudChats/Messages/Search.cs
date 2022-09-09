using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1593989278; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("q")] public string Q { get; set; }

        [MaybeNull]
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

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteString(Q);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkfromId = writer.WriteObject(FromId);
                if (checkfromId.IsError)
                {
                    return checkfromId;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(TopMsgId.Value);
            }

            var checkfilter = writer.WriteObject(Filter);
            if (checkfilter.IsError)
            {
                return checkfilter;
            }

            writer.WriteInt32(MinDate);
            writer.WriteInt32(MaxDate);
            writer.WriteInt32(OffsetId);
            writer.WriteInt32(AddOffset);
            writer.WriteInt32(Limit);
            writer.WriteInt32(MaxId);
            writer.WriteInt32(MinId);
            writer.WriteInt64(Hash);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryq = reader.ReadString();
            if (tryq.IsError)
            {
                return ReadResult<IObject>.Move(tryq);
            }

            Q = tryq.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfromId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
                if (tryfromId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfromId);
                }

                FromId = tryfromId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trytopMsgId = reader.ReadInt32();
                if (trytopMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trytopMsgId);
                }

                TopMsgId = trytopMsgId.Value;
            }

            var tryfilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
            if (tryfilter.IsError)
            {
                return ReadResult<IObject>.Move(tryfilter);
            }

            Filter = tryfilter.Value;
            var tryminDate = reader.ReadInt32();
            if (tryminDate.IsError)
            {
                return ReadResult<IObject>.Move(tryminDate);
            }

            MinDate = tryminDate.Value;
            var trymaxDate = reader.ReadInt32();
            if (trymaxDate.IsError)
            {
                return ReadResult<IObject>.Move(trymaxDate);
            }

            MaxDate = trymaxDate.Value;
            var tryoffsetId = reader.ReadInt32();
            if (tryoffsetId.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetId);
            }

            OffsetId = tryoffsetId.Value;
            var tryaddOffset = reader.ReadInt32();
            if (tryaddOffset.IsError)
            {
                return ReadResult<IObject>.Move(tryaddOffset);
            }

            AddOffset = tryaddOffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }

            MaxId = trymaxId.Value;
            var tryminId = reader.ReadInt32();
            if (tryminId.IsError)
            {
                return ReadResult<IObject>.Move(tryminId);
            }

            MinId = tryminId.Value;
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.search";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new Search();
            newClonedObject.Flags = Flags;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Q = Q;
            if (FromId is not null)
            {
                var cloneFromId = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)FromId.Clone();
                if (cloneFromId is null)
                {
                    return null;
                }

                newClonedObject.FromId = cloneFromId;
            }

            newClonedObject.TopMsgId = TopMsgId;
            var cloneFilter = (CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase?)Filter.Clone();
            if (cloneFilter is null)
            {
                return null;
            }

            newClonedObject.Filter = cloneFilter;
            newClonedObject.MinDate = MinDate;
            newClonedObject.MaxDate = MaxDate;
            newClonedObject.OffsetId = OffsetId;
            newClonedObject.AddOffset = AddOffset;
            newClonedObject.Limit = Limit;
            newClonedObject.MaxId = MaxId;
            newClonedObject.MinId = MinId;
            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not Search castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Q != castedOther.Q)
            {
                return true;
            }

            if (FromId is null && castedOther.FromId is not null || FromId is not null && castedOther.FromId is null)
            {
                return true;
            }

            if (FromId is not null && castedOther.FromId is not null && FromId.Compare(castedOther.FromId))
            {
                return true;
            }

            if (TopMsgId != castedOther.TopMsgId)
            {
                return true;
            }

            if (Filter.Compare(castedOther.Filter))
            {
                return true;
            }

            if (MinDate != castedOther.MinDate)
            {
                return true;
            }

            if (MaxDate != castedOther.MaxDate)
            {
                return true;
            }

            if (OffsetId != castedOther.OffsetId)
            {
                return true;
            }

            if (AddOffset != castedOther.AddOffset)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            if (MaxId != castedOther.MaxId)
            {
                return true;
            }

            if (MinId != castedOther.MinId)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}