using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;

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
        public abstract bool Compare(IObject other);
#nullable disable
    }
}