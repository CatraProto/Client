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
    public partial class DocumentAttributeVideo : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            RoundMessage = 1 << 0,
            SupportsStreaming = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 250621158; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("round_message")]
        public bool RoundMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("supports_streaming")]
        public bool SupportsStreaming { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int Duration { get; set; }

        [Newtonsoft.Json.JsonProperty("w")]
        public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")]
        public int H { get; set; }


#nullable enable
        public DocumentAttributeVideo(int duration, int w, int h)
        {
            Duration = duration;
            W = w;
            H = h;

        }
#nullable disable
        internal DocumentAttributeVideo()
        {
        }

        public override void UpdateFlags()
        {
            Flags = RoundMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SupportsStreaming ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Duration);
            writer.WriteInt32(W);
            writer.WriteInt32(H);

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
            RoundMessage = FlagsHelper.IsFlagSet(Flags, 0);
            SupportsStreaming = FlagsHelper.IsFlagSet(Flags, 1);
            var tryduration = reader.ReadInt32();
            if (tryduration.IsError)
            {
                return ReadResult<IObject>.Move(tryduration);
            }
            Duration = tryduration.Value;
            var tryw = reader.ReadInt32();
            if (tryw.IsError)
            {
                return ReadResult<IObject>.Move(tryw);
            }
            W = tryw.Value;
            var tryh = reader.ReadInt32();
            if (tryh.IsError)
            {
                return ReadResult<IObject>.Move(tryh);
            }
            H = tryh.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "documentAttributeVideo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DocumentAttributeVideo
            {
                Flags = Flags,
                RoundMessage = RoundMessage,
                SupportsStreaming = SupportsStreaming,
                Duration = Duration,
                W = W,
                H = H
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not DocumentAttributeVideo castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (RoundMessage != castedOther.RoundMessage)
            {
                return true;
            }
            if (SupportsStreaming != castedOther.SupportsStreaming)
            {
                return true;
            }
            if (Duration != castedOther.Duration)
            {
                return true;
            }
            if (W != castedOther.W)
            {
                return true;
            }
            if (H != castedOther.H)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}