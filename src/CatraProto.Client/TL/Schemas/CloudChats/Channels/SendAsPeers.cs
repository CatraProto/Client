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
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class SendAsPeers : CatraProto.Client.TL.Schemas.CloudChats.Channels.SendAsPeersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2091463255; }

        [Newtonsoft.Json.JsonProperty("peers")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Peers { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public SendAsPeers(List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> peers, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Peers = peers;
            Chats = chats;
            Users = users;

        }
#nullable disable
        internal SendAsPeers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeers = writer.WriteVector(Peers, false);
            if (checkpeers.IsError)
            {
                return checkpeers;
            }
            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
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
            var trypeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypeers.IsError)
            {
                return ReadResult<IObject>.Move(trypeers);
            }
            Peers = trypeers.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }
            Chats = trychats.Value;
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
            return "channels.sendAsPeers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SendAsPeers
            {
                Peers = new List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>()
            };
            foreach (var peers in Peers)
            {
                var clonepeers = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)peers.Clone();
                if (clonepeers is null)
                {
                    return null;
                }
                newClonedObject.Peers.Add(clonepeers);
            }
            newClonedObject.Chats = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
            foreach (var chats in Chats)
            {
                var clonechats = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chats.Clone();
                if (clonechats is null)
                {
                    return null;
                }
                newClonedObject.Chats.Add(clonechats);
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

        public override bool Compare(IObject other)
        {
            if (other is not SendAsPeers castedOther)
            {
                return true;
            }
            var peerssize = castedOther.Peers.Count;
            if (peerssize != Peers.Count)
            {
                return true;
            }
            for (var i = 0; i < peerssize; i++)
            {
                if (castedOther.Peers[i].Compare(Peers[i]))
                {
                    return true;
                }
            }
            var chatssize = castedOther.Chats.Count;
            if (chatssize != Chats.Count)
            {
                return true;
            }
            for (var i = 0; i < chatssize; i++)
            {
                if (castedOther.Chats[i].Compare(Chats[i]))
                {
                    return true;
                }
            }
            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }
            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i].Compare(Users[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}