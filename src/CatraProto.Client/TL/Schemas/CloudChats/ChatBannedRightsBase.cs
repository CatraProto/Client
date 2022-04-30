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
    public abstract class ChatBannedRightsBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("view_messages")]
        public abstract bool ViewMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("send_messages")]
        public abstract bool SendMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("send_media")]
        public abstract bool SendMedia { get; set; }

        [Newtonsoft.Json.JsonProperty("send_stickers")]
        public abstract bool SendStickers { get; set; }

        [Newtonsoft.Json.JsonProperty("send_gifs")]
        public abstract bool SendGifs { get; set; }

        [Newtonsoft.Json.JsonProperty("send_games")]
        public abstract bool SendGames { get; set; }

        [Newtonsoft.Json.JsonProperty("send_inline")]
        public abstract bool SendInline { get; set; }

        [Newtonsoft.Json.JsonProperty("embed_links")]
        public abstract bool EmbedLinks { get; set; }

        [Newtonsoft.Json.JsonProperty("send_polls")]
        public abstract bool SendPolls { get; set; }

        [Newtonsoft.Json.JsonProperty("change_info")]
        public abstract bool ChangeInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("invite_users")]
        public abstract bool InviteUsers { get; set; }

        [Newtonsoft.Json.JsonProperty("pin_messages")]
        public abstract bool PinMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("until_date")]
        public abstract int UntilDate { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
