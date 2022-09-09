using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

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