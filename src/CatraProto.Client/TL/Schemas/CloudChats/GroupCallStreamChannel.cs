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
    public partial class GroupCallStreamChannel : CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2132064081; }

        [Newtonsoft.Json.JsonProperty("channel")]
        public sealed override int Channel { get; set; }

        [Newtonsoft.Json.JsonProperty("scale")]
        public sealed override int Scale { get; set; }

        [Newtonsoft.Json.JsonProperty("last_timestamp_ms")]
        public sealed override long LastTimestampMs { get; set; }


#nullable enable
        public GroupCallStreamChannel(int channel, int scale, long lastTimestampMs)
        {
            Channel = channel;
            Scale = scale;
            LastTimestampMs = lastTimestampMs;
        }
#nullable disable
        internal GroupCallStreamChannel()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Channel);
            writer.WriteInt32(Scale);
            writer.WriteInt64(LastTimestampMs);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychannel = reader.ReadInt32();
            if (trychannel.IsError)
            {
                return ReadResult<IObject>.Move(trychannel);
            }

            Channel = trychannel.Value;
            var tryscale = reader.ReadInt32();
            if (tryscale.IsError)
            {
                return ReadResult<IObject>.Move(tryscale);
            }

            Scale = tryscale.Value;
            var trylastTimestampMs = reader.ReadInt64();
            if (trylastTimestampMs.IsError)
            {
                return ReadResult<IObject>.Move(trylastTimestampMs);
            }

            LastTimestampMs = trylastTimestampMs.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "groupCallStreamChannel";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new GroupCallStreamChannel();
            newClonedObject.Channel = Channel;
            newClonedObject.Scale = Scale;
            newClonedObject.LastTimestampMs = LastTimestampMs;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not GroupCallStreamChannel castedOther)
            {
                return true;
            }

            if (Channel != castedOther.Channel)
            {
                return true;
            }

            if (Scale != castedOther.Scale)
            {
                return true;
            }

            if (LastTimestampMs != castedOther.LastTimestampMs)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}