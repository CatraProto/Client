using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PeerChannel : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1566230754; }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }


#nullable enable
        public PeerChannel(long channelId)
        {
            ChannelId = channelId;
        }
#nullable disable
        internal PeerChannel()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChannelId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannelId = reader.ReadInt64();
            if (trychannelId.IsError)
            {
                return ReadResult<IObject>.Move(trychannelId);
            }

            ChannelId = trychannelId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "peerChannel";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerChannel();
            newClonedObject.ChannelId = ChannelId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerChannel castedOther)
            {
                return true;
            }

            if (ChannelId != castedOther.ChannelId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}