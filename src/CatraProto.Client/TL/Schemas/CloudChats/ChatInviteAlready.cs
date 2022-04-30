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
    public partial class ChatInviteAlready : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1516793212; }

        [Newtonsoft.Json.JsonProperty("chat")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Chat { get; set; }


#nullable enable
        public ChatInviteAlready(CatraProto.Client.TL.Schemas.CloudChats.ChatBase chat)
        {
            Chat = chat;

        }
#nullable disable
        internal ChatInviteAlready()
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
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatInviteAlready";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInviteAlready();
            var cloneChat = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)Chat.Clone();
            if (cloneChat is null)
            {
                return null;
            }
            newClonedObject.Chat = cloneChat;
            return newClonedObject;

        }
#nullable disable
    }
}