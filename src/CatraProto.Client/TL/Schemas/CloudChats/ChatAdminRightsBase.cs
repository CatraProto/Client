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
    public abstract class ChatAdminRightsBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("change_info")]
        public abstract bool ChangeInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("post_messages")]
        public abstract bool PostMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("edit_messages")]
        public abstract bool EditMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("delete_messages")]
        public abstract bool DeleteMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("ban_users")]
        public abstract bool BanUsers { get; set; }

        [Newtonsoft.Json.JsonProperty("invite_users")]
        public abstract bool InviteUsers { get; set; }

        [Newtonsoft.Json.JsonProperty("pin_messages")]
        public abstract bool PinMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("add_admins")]
        public abstract bool AddAdmins { get; set; }

        [Newtonsoft.Json.JsonProperty("anonymous")]
        public abstract bool Anonymous { get; set; }

        [Newtonsoft.Json.JsonProperty("manage_call")]
        public abstract bool ManageCall { get; set; }

        [Newtonsoft.Json.JsonProperty("other")]
        public abstract bool Other { get; set; }

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
