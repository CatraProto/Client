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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class BotCallbackAnswer : CatraProto.Client.TL.Schemas.CloudChats.Messages.BotCallbackAnswerBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Alert = 1 << 1,
            HasUrl = 1 << 3,
            NativeUi = 1 << 4,
            Message = 1 << 0,
            Url = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 911761060; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("alert")]
        public sealed override bool Alert { get; set; }

        [Newtonsoft.Json.JsonProperty("has_url")]
        public sealed override bool HasUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("native_ui")]
        public sealed override bool NativeUi { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("message")]
        public sealed override string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("cache_time")]
        public sealed override int CacheTime { get; set; }


#nullable enable
        public BotCallbackAnswer(int cacheTime)
        {
            CacheTime = cacheTime;

        }
#nullable disable
        internal BotCallbackAnswer()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Alert ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = HasUrl ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = NativeUi ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(Message);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {

                writer.WriteString(Url);
            }

            writer.WriteInt32(CacheTime);

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
            Alert = FlagsHelper.IsFlagSet(Flags, 1);
            HasUrl = FlagsHelper.IsFlagSet(Flags, 3);
            NativeUi = FlagsHelper.IsFlagSet(Flags, 4);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trymessage = reader.ReadString();
                if (trymessage.IsError)
                {
                    return ReadResult<IObject>.Move(trymessage);
                }
                Message = trymessage.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryurl = reader.ReadString();
                if (tryurl.IsError)
                {
                    return ReadResult<IObject>.Move(tryurl);
                }
                Url = tryurl.Value;
            }

            var trycacheTime = reader.ReadInt32();
            if (trycacheTime.IsError)
            {
                return ReadResult<IObject>.Move(trycacheTime);
            }
            CacheTime = trycacheTime.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.botCallbackAnswer";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BotCallbackAnswer
            {
                Flags = Flags,
                Alert = Alert,
                HasUrl = HasUrl,
                NativeUi = NativeUi,
                Message = Message,
                Url = Url,
                CacheTime = CacheTime
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not BotCallbackAnswer castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Alert != castedOther.Alert)
            {
                return true;
            }
            if (HasUrl != castedOther.HasUrl)
            {
                return true;
            }
            if (NativeUi != castedOther.NativeUi)
            {
                return true;
            }
            if (Message != castedOther.Message)
            {
                return true;
            }
            if (Url != castedOther.Url)
            {
                return true;
            }
            if (CacheTime != castedOther.CacheTime)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}