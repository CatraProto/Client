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
    public partial class RecentMeUrlChatInvite : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -347535331; }

        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }

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
            var newClonedObject = new RecentMeUrlChatInvite
            {
                Url = Url
            };
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