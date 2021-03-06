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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class Chats : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1694474197; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> ChatsField { get; set; }


#nullable enable
        public Chats(List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chatsField)
        {
            ChatsField = chatsField;

        }
#nullable disable
        internal Chats()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchatsField = writer.WriteVector(ChatsField, false);
            if (checkchatsField.IsError)
            {
                return checkchatsField;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatsField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychatsField.IsError)
            {
                return ReadResult<IObject>.Move(trychatsField);
            }
            ChatsField = trychatsField.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.chats";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Chats
            {
                ChatsField = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>()
            };
            foreach (var chatsField in ChatsField)
            {
                var clonechatsField = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chatsField.Clone();
                if (clonechatsField is null)
                {
                    return null;
                }
                newClonedObject.ChatsField.Add(clonechatsField);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not Chats castedOther)
            {
                return true;
            }
            var chatsFieldsize = castedOther.ChatsField.Count;
            if (chatsFieldsize != ChatsField.Count)
            {
                return true;
            }
            for (var i = 0; i < chatsFieldsize; i++)
            {
                if (castedOther.ChatsField[i].Compare(ChatsField[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}