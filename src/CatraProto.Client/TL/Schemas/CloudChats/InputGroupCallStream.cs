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

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputGroupCallStream : CatraProto.Client.TL.Schemas.CloudChats.InputFileLocationBase
    {
        [Flags]
        public enum FlagsEnum
        {
            VideoChannel = 1 << 0,
            VideoQuality = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 93890858; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("call")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("time_ms")]
        public long TimeMs { get; set; }

        [Newtonsoft.Json.JsonProperty("scale")]
        public int Scale { get; set; }

        [Newtonsoft.Json.JsonProperty("video_channel")]
        public int? VideoChannel { get; set; }

        [Newtonsoft.Json.JsonProperty("video_quality")]
        public int? VideoQuality { get; set; }


#nullable enable
        public InputGroupCallStream(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call, long timeMs, int scale)
        {
            Call = call;
            TimeMs = timeMs;
            Scale = scale;

        }
#nullable disable
        internal InputGroupCallStream()
        {
        }

        public override void UpdateFlags()
        {
            Flags = VideoChannel == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = VideoQuality == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }
            writer.WriteInt64(TimeMs);
            writer.WriteInt32(Scale);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(VideoChannel.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(VideoQuality.Value);
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
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }
            Call = trycall.Value;
            var trytimeMs = reader.ReadInt64();
            if (trytimeMs.IsError)
            {
                return ReadResult<IObject>.Move(trytimeMs);
            }
            TimeMs = trytimeMs.Value;
            var tryscale = reader.ReadInt32();
            if (tryscale.IsError)
            {
                return ReadResult<IObject>.Move(tryscale);
            }
            Scale = tryscale.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryvideoChannel = reader.ReadInt32();
                if (tryvideoChannel.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideoChannel);
                }
                VideoChannel = tryvideoChannel.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryvideoQuality = reader.ReadInt32();
                if (tryvideoQuality.IsError)
                {
                    return ReadResult<IObject>.Move(tryvideoQuality);
                }
                VideoQuality = tryvideoQuality.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputGroupCallStream";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputGroupCallStream
            {
                Flags = Flags
            };
            var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
            if (cloneCall is null)
            {
                return null;
            }
            newClonedObject.Call = cloneCall;
            newClonedObject.TimeMs = TimeMs;
            newClonedObject.Scale = Scale;
            newClonedObject.VideoChannel = VideoChannel;
            newClonedObject.VideoQuality = VideoQuality;
            return newClonedObject;

        }
#nullable disable
    }
}