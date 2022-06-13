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
    public partial class AttachMenuBots : CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1011024320; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("bots")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotBase> Bots { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public AttachMenuBots(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotBase> bots, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Hash = hash;
            Bots = bots;
            Users = users;

        }
#nullable disable
        internal AttachMenuBots()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkbots = writer.WriteVector(Bots, false);
            if (checkbots.IsError)
            {
                return checkbots;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var trybots = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trybots.IsError)
            {
                return ReadResult<IObject>.Move(trybots);
            }
            Bots = trybots.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "attachMenuBots";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AttachMenuBots
            {
                Hash = Hash,
                Bots = new List<CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotBase>()
            };
            foreach (var bots in Bots)
            {
                var clonebots = (CatraProto.Client.TL.Schemas.CloudChats.AttachMenuBotBase?)bots.Clone();
                if (clonebots is null)
                {
                    return null;
                }
                newClonedObject.Bots.Add(clonebots);
            }
            newClonedObject.Users = new List<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }
                newClonedObject.Users.Add(cloneusers);
            }
            return newClonedObject;

        }
#nullable disable
    }
}