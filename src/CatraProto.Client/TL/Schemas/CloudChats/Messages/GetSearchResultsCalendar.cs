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
    public partial class GetSearchResultsCalendar : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1240514025; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id")]
        public int OffsetId { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_date")]
        public int OffsetDate { get; set; }


#nullable enable
        public GetSearchResultsCalendar(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase filter, int offsetId, int offsetDate)
        {
            Peer = peer;
            Filter = filter;
            OffsetId = offsetId;
            OffsetDate = offsetDate;
        }
#nullable disable

        internal GetSearchResultsCalendar()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            var checkfilter = writer.WriteObject(Filter);
            if (checkfilter.IsError)
            {
                return checkfilter;
            }

            writer.WriteInt32(OffsetId);
            writer.WriteInt32(OffsetDate);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryfilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase>();
            if (tryfilter.IsError)
            {
                return ReadResult<IObject>.Move(tryfilter);
            }

            Filter = tryfilter.Value;
            var tryoffsetId = reader.ReadInt32();
            if (tryoffsetId.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetId);
            }

            OffsetId = tryoffsetId.Value;
            var tryoffsetDate = reader.ReadInt32();
            if (tryoffsetDate.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetDate);
            }

            OffsetDate = tryoffsetDate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getSearchResultsCalendar";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetSearchResultsCalendar();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            var cloneFilter = (CatraProto.Client.TL.Schemas.CloudChats.MessagesFilterBase?)Filter.Clone();
            if (cloneFilter is null)
            {
                return null;
            }

            newClonedObject.Filter = cloneFilter;
            newClonedObject.OffsetId = OffsetId;
            newClonedObject.OffsetDate = OffsetDate;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetSearchResultsCalendar castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Filter.Compare(castedOther.Filter))
            {
                return true;
            }

            if (OffsetId != castedOther.OffsetId)
            {
                return true;
            }

            if (OffsetDate != castedOther.OffsetDate)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}