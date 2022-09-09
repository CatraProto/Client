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
    public partial class GetUnreadMentions : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1180140658; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

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


#nullable enable
        public GetUnreadMentions(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int addOffset, int limit, int maxId, int minId)
        {
            Peer = peer;
            OffsetId = offsetId;
            AddOffset = addOffset;
            Limit = limit;
            MaxId = maxId;
            MinId = minId;
        }
#nullable disable

        internal GetUnreadMentions()
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

            writer.WriteInt32(OffsetId);
            writer.WriteInt32(AddOffset);
            writer.WriteInt32(Limit);
            writer.WriteInt32(MaxId);
            writer.WriteInt32(MinId);

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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getUnreadMentions";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetUnreadMentions();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.OffsetId = OffsetId;
            newClonedObject.AddOffset = AddOffset;
            newClonedObject.Limit = Limit;
            newClonedObject.MaxId = MaxId;
            newClonedObject.MinId = MinId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetUnreadMentions castedOther)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
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

            return false;
        }
#nullable disable
    }
}