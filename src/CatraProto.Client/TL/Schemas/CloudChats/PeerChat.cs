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
    public partial class PeerChat : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 918946202; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


#nullable enable
        public PeerChat(long chatId)
        {
            ChatId = chatId;

        }
#nullable disable
        internal PeerChat()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChatId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }
            ChatId = trychatId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "peerChat";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerChat
            {
                ChatId = ChatId
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerChat castedOther)
            {
                return true;
            }
            if (ChatId != castedOther.ChatId)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}