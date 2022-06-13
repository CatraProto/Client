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
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class UserInfo : CatraProto.Client.TL.Schemas.CloudChats.Help.UserInfoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 32192344; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("entities")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        [Newtonsoft.Json.JsonProperty("author")]
        public string Author { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }


#nullable enable
        public UserInfo(string message, List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities, string author, int date)
        {
            Message = message;
            Entities = entities;
            Author = author;
            Date = date;

        }
#nullable disable
        internal UserInfo()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Message);
            var checkentities = writer.WriteVector(Entities, false);
            if (checkentities.IsError)
            {
                return checkentities;
            }

            writer.WriteString(Author);
            writer.WriteInt32(Date);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }
            Message = trymessage.Value;
            var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryentities.IsError)
            {
                return ReadResult<IObject>.Move(tryentities);
            }
            Entities = tryentities.Value;
            var tryauthor = reader.ReadString();
            if (tryauthor.IsError)
            {
                return ReadResult<IObject>.Move(tryauthor);
            }
            Author = tryauthor.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.userInfo";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UserInfo
            {
                Message = Message,
                Entities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>()
            };
            foreach (var entities in Entities)
            {
                var cloneentities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)entities.Clone();
                if (cloneentities is null)
                {
                    return null;
                }
                newClonedObject.Entities.Add(cloneentities);
            }
            newClonedObject.Author = Author;
            newClonedObject.Date = Date;
            return newClonedObject;

        }
#nullable disable
    }
}