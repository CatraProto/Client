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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class WebViewMessageSent : CatraProto.Client.TL.Schemas.CloudChats.WebViewMessageSentBase
    {
        [Flags]
        public enum FlagsEnum
        {
            MsgId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 211046684; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("msg_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase MsgId { get; set; }



        public WebViewMessageSent()
        {
        }

        public override void UpdateFlags()
        {
            Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkmsgId = writer.WriteObject(MsgId);
                if (checkmsgId.IsError)
                {
                    return checkmsgId;
                }
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trymsgId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase>();
                if (trymsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trymsgId);
                }
                MsgId = trymsgId.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "webViewMessageSent";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebViewMessageSent
            {
                Flags = Flags
            };
            if (MsgId is not null)
            {
                var cloneMsgId = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageIDBase?)MsgId.Clone();
                if (cloneMsgId is null)
                {
                    return null;
                }
                newClonedObject.MsgId = cloneMsgId;
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not WebViewMessageSent castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (MsgId is null && castedOther.MsgId is not null || MsgId is not null && castedOther.MsgId is null)
            {
                return true;
            }
            if (MsgId is not null && castedOther.MsgId is not null && MsgId.Compare(castedOther.MsgId))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}