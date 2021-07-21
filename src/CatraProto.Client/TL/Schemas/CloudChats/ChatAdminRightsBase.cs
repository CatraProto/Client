using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatAdminRightsBase : IObject
    {

[JsonPropertyName("change_info")]
		public abstract bool ChangeInfo { get; set; }

[JsonPropertyName("post_messages")]
		public abstract bool PostMessages { get; set; }

[JsonPropertyName("edit_messages")]
		public abstract bool EditMessages { get; set; }

[JsonPropertyName("delete_messages")]
		public abstract bool DeleteMessages { get; set; }

[JsonPropertyName("ban_users")]
		public abstract bool BanUsers { get; set; }

[JsonPropertyName("invite_users")]
		public abstract bool InviteUsers { get; set; }

[JsonPropertyName("pin_messages")]
		public abstract bool PinMessages { get; set; }

[JsonPropertyName("add_admins")]
		public abstract bool AddAdmins { get; set; }

[JsonPropertyName("anonymous")]
		public abstract bool Anonymous { get; set; }

[JsonPropertyName("manage_call")]
		public abstract bool ManageCall { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
