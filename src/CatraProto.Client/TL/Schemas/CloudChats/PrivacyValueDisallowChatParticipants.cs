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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyValueDisallowChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1103656293; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<long> Chats { get; set; }


#nullable enable
        public PrivacyValueDisallowChatParticipants(List<long> chats)
        {
            Chats = chats;

        }
#nullable disable
        internal PrivacyValueDisallowChatParticipants()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(Chats, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychats = reader.ReadVector<long>(ParserTypes.Int64);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }
            Chats = trychats.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "privacyValueDisallowChatParticipants";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PrivacyValueDisallowChatParticipants
            {
                Chats = new List<long>()
            };
            foreach (var chats in Chats)
            {
                newClonedObject.Chats.Add(chats);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PrivacyValueDisallowChatParticipants castedOther)
            {
                return true;
            }
            var chatssize = castedOther.Chats.Count;
            if (chatssize != Chats.Count)
            {
                return true;
            }
            for (var i = 0; i < chatssize; i++)
            {
                if (castedOther.Chats[i] != Chats[i])
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}