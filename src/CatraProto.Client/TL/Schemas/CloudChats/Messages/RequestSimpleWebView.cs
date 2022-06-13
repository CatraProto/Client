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
    public partial class RequestSimpleWebView : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            ThemeParams = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1790652275; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("url")]
        public string Url { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("theme_params")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase ThemeParams { get; set; }


#nullable enable
        public RequestSimpleWebView(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, string url)
        {
            Bot = bot;
            Url = url;

        }
#nullable disable

        internal RequestSimpleWebView()
        {
        }

        public void UpdateFlags()
        {
            Flags = ThemeParams == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }

            writer.WriteString(Url);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkthemeParams = writer.WriteObject(ThemeParams);
                if (checkthemeParams.IsError)
                {
                    return checkthemeParams;
                }
            }


            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }
            Bot = trybot.Value;
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }
            Url = tryurl.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trythemeParams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
                if (trythemeParams.IsError)
                {
                    return ReadResult<IObject>.Move(trythemeParams);
                }
                ThemeParams = trythemeParams.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.requestSimpleWebView";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RequestSimpleWebView
            {
                Flags = Flags
            };
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }
            newClonedObject.Bot = cloneBot;
            newClonedObject.Url = Url;
            if (ThemeParams is not null)
            {
                var cloneThemeParams = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)ThemeParams.Clone();
                if (cloneThemeParams is null)
                {
                    return null;
                }
                newClonedObject.ThemeParams = cloneThemeParams;
            }
            return newClonedObject;

        }
#nullable disable
    }
}