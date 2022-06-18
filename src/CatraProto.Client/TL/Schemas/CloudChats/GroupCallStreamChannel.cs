/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class GroupCallStreamChannel : CatraProto.Client.TL.Schemas.CloudChats.GroupCallStreamChannelBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2132064081; }

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
            var newClonedObject = new GroupCallStreamChannel
            {
                Channel = Channel,
                Scale = Scale,
                LastTimestampMs = LastTimestampMs
            };
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