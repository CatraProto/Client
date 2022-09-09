using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class RecentMeUrlChatInvite : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -347535331; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase ChatInvite { get; set; }


#nullable enable
        public RecentMeUrlChatInvite(string url, CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase chatInvite)
        {
            Url = url;
            ChatInvite = chatInvite;
        }
#nullable disable
        internal RecentMeUrlChatInvite()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            var checkchatInvite = writer.WriteObject(ChatInvite);
            if (checkchatInvite.IsError)
            {
                return checkchatInvite;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            var trychatInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>();
            if (trychatInvite.IsError)
            {
                return ReadResult<IObject>.Move(trychatInvite);
            }

            ChatInvite = trychatInvite.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "recentMeUrlChatInvite";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RecentMeUrlChatInvite();
            newClonedObject.Url = Url;
            var cloneChatInvite = (CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase?)ChatInvite.Clone();
            if (cloneChatInvite is null)
            {
                return null;
            }

            newClonedObject.ChatInvite = cloneChatInvite;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RecentMeUrlChatInvite castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (ChatInvite.Compare(castedOther.ChatInvite))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}