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

using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class UserFullBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("blocked")]
        public abstract bool Blocked { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_calls_available")]
        public abstract bool PhoneCallsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_calls_private")]
        public abstract bool PhoneCallsPrivate { get; set; }

        [Newtonsoft.Json.JsonProperty("can_pin_message")]
        public abstract bool CanPinMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("has_scheduled")]
        public abstract bool HasScheduled { get; set; }

        [Newtonsoft.Json.JsonProperty("video_calls_available")]
        public abstract bool VideoCallsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract long Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public abstract string About { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("profile_photo")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ProfilePhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_settings")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("bot_info")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase BotInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_msg_id")]
        public abstract int? PinnedMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("common_chats_count")]
        public abstract int CommonChatsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public abstract int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public abstract int? TtlPeriod { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("theme_emoticon")]
        public abstract string ThemeEmoticon { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("private_forward_name")]
        public abstract string PrivateForwardName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("bot_group_admin_rights")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase BotGroupAdminRights { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("bot_broadcast_admin_rights")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase BotBroadcastAdminRights { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
        public abstract bool Compare(IObject other);
#nullable disable
    }
}
