using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
    public partial class GetMessagePublicForwards : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1445996571; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_rate")]
        public int OffsetRate { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase OffsetPeer { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id")]
        public int OffsetId { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetMessagePublicForwards(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, int msgId, int offsetRate, CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase offsetPeer, int offsetId, int limit)
        {
            Channel = channel;
            MsgId = msgId;
            OffsetRate = offsetRate;
            OffsetPeer = offsetPeer;
            OffsetId = offsetId;
            Limit = limit;
        }
#nullable disable

        internal GetMessagePublicForwards()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchannel = writer.WriteObject(Channel);
            if (checkchannel.IsError)
            {
                return checkchannel;
            }

            writer.WriteInt32(MsgId);
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
            var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }

            MsgId = trymsgId.Value;
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
            return "stats.getMessagePublicForwards";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetMessagePublicForwards();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            newClonedObject.MsgId = MsgId;
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
            if (other is not GetMessagePublicForwards castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (MsgId != castedOther.MsgId)
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