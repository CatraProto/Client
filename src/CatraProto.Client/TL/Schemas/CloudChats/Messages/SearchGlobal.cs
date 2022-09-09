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
    public partial class SearchGlobal : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1271290010; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("q")] public string Q { get; set; }

        [Newtonsoft.Json.JsonProperty("filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("min_date")]
        public int MinDate { get; set; }

        [Newtonsoft.Json.JsonProperty("max_date")]
        public int MaxDate { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_rate")]
        public int OffsetRate { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase OffsetPeer { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id")]
        public int OffsetId { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public SearchGlobal(string q, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int minDate, int maxDate, int offsetRate, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int offsetId, int limit)
        {
            Q = q;
            Filter = filter;
            MinDate = minDate;
            MaxDate = maxDate;
            OffsetRate = offsetRate;
            OffsetPeer = offsetPeer;
            OffsetId = offsetId;
            Limit = limit;
        }
#nullable disable

        internal SearchGlobal()
        {
        }

        public void UpdateFlags()
        {
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(FolderId.Value);
            }


            writer.WriteString(Q);
            var checkfilter = writer.WriteObject(Filter);
            if (checkfilter.IsError)
            {
                return checkfilter;
            }

            writer.WriteInt32(MinDate);
            writer.WriteInt32(MaxDate);
            writer.WriteInt32(OffsetRate);
            var checkoffsetPeer = writer.WriteObject(OffsetPeer);
            if (checkoffsetPeer.IsError)
            {
                return checkoffsetPeer;
            }

            writer.WriteInt32(OffsetId);
            writer.WriteInt32(Limit);

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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }

                FolderId = tryfolderId.Value;
            }

            var tryq = reader.ReadString();
            if (tryq.IsError)
            {
                return ReadResult<IObject>.Move(tryq);
            }

            Q = tryq.Value;
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
            var tryoffsetRate = reader.ReadInt32();
            if (tryoffsetRate.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetRate);
            }

            OffsetRate = tryoffsetRate.Value;
            var tryoffsetPeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (tryoffsetPeer.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetPeer);
            }

            OffsetPeer = tryoffsetPeer.Value;
            var tryoffsetId = reader.ReadInt32();
            if (tryoffsetId.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetId);
            }

            OffsetId = tryoffsetId.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.searchGlobal";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SearchGlobal();
            newClonedObject.Flags = Flags;
            newClonedObject.FolderId = FolderId;
            newClonedObject.Q = Q;
            var cloneFilter = (CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase?)Filter.Clone();
            if (cloneFilter is null)
            {
                return null;
            }

            newClonedObject.Filter = cloneFilter;
            newClonedObject.MinDate = MinDate;
            newClonedObject.MaxDate = MaxDate;
            newClonedObject.OffsetRate = OffsetRate;
            var cloneOffsetPeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)OffsetPeer.Clone();
            if (cloneOffsetPeer is null)
            {
                return null;
            }

            newClonedObject.OffsetPeer = cloneOffsetPeer;
            newClonedObject.OffsetId = OffsetId;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SearchGlobal castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
            {
                return true;
            }

            if (Q != castedOther.Q)
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

            if (OffsetRate != castedOther.OffsetRate)
            {
                return true;
            }

            if (OffsetPeer.Compare(castedOther.OffsetPeer))
            {
                return true;
            }

            if (OffsetId != castedOther.OffsetId)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}