using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class GetParticipants : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2010044880; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase Filter { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }


#nullable enable
        public GetParticipants(CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel, CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase filter, int offset, int limit, long hash)
        {
            Channel = channel;
            Filter = filter;
            Offset = offset;
            Limit = limit;
            Hash = hash;
        }
#nullable disable

        internal GetParticipants()
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

            var checkfilter = writer.WriteObject(Filter);
            if (checkfilter.IsError)
            {
                return checkfilter;
            }

            writer.WriteInt32(Offset);
            writer.WriteInt32(Limit);
            writer.WriteInt64(Hash);

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
            var tryfilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase>();
            if (tryfilter.IsError)
            {
                return ReadResult<IObject>.Move(tryfilter);
            }

            Filter = tryfilter.Value;
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
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
            return "channels.getParticipants";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetParticipants();
            var cloneChannel = (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase?)Channel.Clone();
            if (cloneChannel is null)
            {
                return null;
            }

            newClonedObject.Channel = cloneChannel;
            var cloneFilter = (CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase?)Filter.Clone();
            if (cloneFilter is null)
            {
                return null;
            }

            newClonedObject.Filter = cloneFilter;
            newClonedObject.Offset = Offset;
            newClonedObject.Limit = Limit;
            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetParticipants castedOther)
            {
                return true;
            }

            if (Channel.Compare(castedOther.Channel))
            {
                return true;
            }

            if (Filter.Compare(castedOther.Filter))
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
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