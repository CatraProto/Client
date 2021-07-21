using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class ChatBannedRightsBase : IObject
    {

[JsonPropertyName("view_messages")]
		public abstract bool ViewMessages { get; set; }

[JsonPropertyName("send_messages")]
		public abstract bool SendMessages { get; set; }

[JsonPropertyName("send_media")]
		public abstract bool SendMedia { get; set; }

[JsonPropertyName("send_stickers")]
		public abstract bool SendStickers { get; set; }

[JsonPropertyName("send_gifs")]
		public abstract bool SendGifs { get; set; }

[JsonPropertyName("send_games")]
		public abstract bool SendGames { get; set; }

[JsonPropertyName("send_inline")]
		public abstract bool SendInline { get; set; }

[JsonPropertyName("embed_links")]
		public abstract bool EmbedLinks { get; set; }

[JsonPropertyName("send_polls")]
		public abstract bool SendPolls { get; set; }

[JsonPropertyName("change_info")]
		public abstract bool ChangeInfo { get; set; }

[JsonPropertyName("invite_users")]
		public abstract bool InviteUsers { get; set; }

[JsonPropertyName("pin_messages")]
		public abstract bool PinMessages { get; set; }

[JsonPropertyName("until_date")]
		public abstract int UntilDate { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
