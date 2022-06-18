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
    public partial class ChatInvitePeek : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1634294960; }

        [Newtonsoft.Json.JsonProperty("chat")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public int Expires { get; set; }


#nullable enable
        public ChatInvitePeek(CatraProto.Client.TL.Schemas.CloudChats.ChatBase chat, int expires)
        {
            Chat = chat;
            Expires = expires;

        }
#nullable disable
        internal ChatInvitePeek()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchat = writer.WriteObject(Chat);
            if (checkchat.IsError)
            {
                return checkchat;
            }
            writer.WriteInt32(Expires);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychat = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            if (trychat.IsError)
            {
                return ReadResult<IObject>.Move(trychat);
            }
            Chat = trychat.Value;
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }
            Expires = tryexpires.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatInvitePeek";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInvitePeek();
            var cloneChat = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)Chat.Clone();
            if (cloneChat is null)
            {
                return null;
            }
            newClonedObject.Chat = cloneChat;
            newClonedObject.Expires = Expires;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatInvitePeek castedOther)
            {
                return true;
            }
            if (Chat.Compare(castedOther.Chat))
            {
                return true;
            }
            if (Expires != castedOther.Expires)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}