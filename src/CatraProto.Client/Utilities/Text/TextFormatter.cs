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

using System.Collections.Generic;
using System.Text;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.Utilities
{
    public enum MarkupType
    {
        None = 0x00,
        Bold = 0x01,
        Italic = 0x02,
        Monospace = 0x04,
        Underline = 0x08,
        Strikethrough = 0x10,
        Spoiler = 0x20,
    }

    public enum MarkupOptions
    {
        None = 0x00,
        SkipTrailingSpaces = 0x01
    }

    public class TextFormatter
    {
        private readonly List<MessageEntityBase> _entities;
        private readonly StringBuilder _stringBuilder;
        private readonly TelegramClient _client;
        private readonly MarkupOptions _options;

        internal TextFormatter(TelegramClient client, MarkupOptions options)
        {
            _entities = new List<MessageEntityBase>();
            _stringBuilder = new StringBuilder();
            _client = client;
            _options = options;
        }

        public TextFormatter AddPlain(string text)
        {
            _stringBuilder.Append(text);
            return this;
        }

        public TextFormatter AddMarkup(string text, MarkupType type)
        {
            var intType = (int)type;
            var textLength = GetEntityLength(text);

            if (textLength > 0)
            {
                if ((intType & (int)MarkupType.Bold) != 0)
                {
                    _entities.Add(new MessageEntityBold(_stringBuilder.Length, textLength));
                }

                if ((intType & (int)MarkupType.Italic) != 0)
                {
                    _entities.Add(new MessageEntityItalic(_stringBuilder.Length, textLength));
                }

                if ((intType & (int)MarkupType.Monospace) != 0)
                {
                    _entities.Add(new MessageEntityCode(_stringBuilder.Length, textLength));
                }

                if ((intType & (int)MarkupType.Underline) != 0)
                {
                    _entities.Add(new MessageEntityUnderline(_stringBuilder.Length, textLength));
                }

                if ((intType & (int)MarkupType.Spoiler) != 0)
                {
                    _entities.Add(new MessageEntitySpoiler(_stringBuilder.Length, textLength));
                }

                if ((intType & (int)MarkupType.Strikethrough) != 0)
                {
                    _entities.Add(new MessageEntityStrike(_stringBuilder.Length, textLength));
                }
            }

            _stringBuilder.Append(text);
            return this;
        }

        public TextFormatter AddLink(string text, string link, MarkupType otherMarkup = MarkupType.None)
        {
            _entities.Add(new MessageEntityTextUrl(_stringBuilder.Length, GetEntityLength(text), link));
            AddMarkup(text, otherMarkup);
            return this;
        }

        public TextFormatter AddMention(string text, long userId, MarkupType otherMarkup = MarkupType.None)
        {
            var inputUser = _client.DatabaseManager.PeerDatabase.ResolveUser(userId);
            if (inputUser is null)
            {
                inputUser = new InputUser(userId, 0);
            }

            _entities.Add(new InputMessageEntityMentionName(_stringBuilder.Length, GetEntityLength(text), inputUser));
            AddMarkup(text, otherMarkup);
            return this;
        }

        public TextFormatter AddCode(string text, string language, MarkupType otherMarkup = MarkupType.None)
        {
            _entities.Add(new MessageEntityPre(_stringBuilder.Length, GetEntityLength(text), language));
            AddMarkup(text, otherMarkup);
            return this;
        }

        public (string Text, List<MessageEntityBase> Entities) GetFormatted()
        {
            return (_stringBuilder.ToString(), _entities);
        }

        private int GetEntityLength(string text)
        {
            if (((int)_options & (int)MarkupOptions.SkipTrailingSpaces) == 0)
            {
                return text.Length;
            }

            var rValue = text.Length;
            for (var i = text.Length - 1; i >= 0; i--)
            {
                if (text[i] != ' ')
                {
                    break;
                }

                rValue--;
            }

            return rValue;
        }
    }
}
