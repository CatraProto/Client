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
    public partial class InputKeyboardButtonUrlAuth : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {
        [Flags]
        public enum FlagsEnum
        {
            RequestWriteAccess = 1 << 0,
            FwdText = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -802258988; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("request_write_access")]
        public bool RequestWriteAccess { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("fwd_text")]
        public string FwdText { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }


#nullable enable
        public InputKeyboardButtonUrlAuth(string text, string url, CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot)
        {
            Text = text;
            Url = url;
            Bot = bot;

        }
#nullable disable
        internal InputKeyboardButtonUrlAuth()
        {
        }

        public override void UpdateFlags()
        {
            Flags = RequestWriteAccess ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = FwdText == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Text);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(FwdText);
            }


            writer.WriteString(Url);
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
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
            RequestWriteAccess = FlagsHelper.IsFlagSet(Flags, 0);
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryfwdText = reader.ReadString();
                if (tryfwdText.IsError)
                {
                    return ReadResult<IObject>.Move(tryfwdText);
                }
                FwdText = tryfwdText.Value;
            }

            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }
            Url = tryurl.Value;
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }
            Bot = trybot.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputKeyboardButtonUrlAuth";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputKeyboardButtonUrlAuth
            {
                Flags = Flags,
                RequestWriteAccess = RequestWriteAccess,
                Text = Text,
                FwdText = FwdText,
                Url = Url
            };
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }
            newClonedObject.Bot = cloneBot;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not InputKeyboardButtonUrlAuth castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (RequestWriteAccess != castedOther.RequestWriteAccess)
            {
                return true;
            }
            if (Text != castedOther.Text)
            {
                return true;
            }
            if (FwdText != castedOther.FwdText)
            {
                return true;
            }
            if (Url != castedOther.Url)
            {
                return true;
            }
            if (Bot.Compare(castedOther.Bot))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}