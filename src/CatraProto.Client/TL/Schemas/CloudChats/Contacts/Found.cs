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
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Found : CatraProto.Client.TL.Schemas.CloudChats.Contacts.FoundBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1290580579; }

        [Newtonsoft.Json.JsonProperty("my_results")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> MyResults { get; set; }

        [Newtonsoft.Json.JsonProperty("results")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> Results { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public Found(List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> myResults, List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase> results, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            MyResults = myResults;
            Results = results;
            Chats = chats;
            Users = users;

        }
#nullable disable
        internal Found()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkmyResults = writer.WriteVector(MyResults, false);
            if (checkmyResults.IsError)
            {
                return checkmyResults;
            }
            var checkresults = writer.WriteVector(Results, false);
            if (checkresults.IsError)
            {
                return checkresults;
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
            var trymyResults = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trymyResults.IsError)
            {
                return ReadResult<IObject>.Move(trymyResults);
            }
            MyResults = trymyResults.Value;
            var tryresults = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryresults.IsError)
            {
                return ReadResult<IObject>.Move(tryresults);
            }
            Results = tryresults.Value;
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
            return "contacts.found";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Found
            {
                MyResults = new List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>()
            };
            foreach (var myResults in MyResults)
            {
                var clonemyResults = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)myResults.Clone();
                if (clonemyResults is null)
                {
                    return null;
                }
                newClonedObject.MyResults.Add(clonemyResults);
            }
            newClonedObject.Results = new List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            foreach (var results in Results)
            {
                var cloneresults = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)results.Clone();
                if (cloneresults is null)
                {
                    return null;
                }
                newClonedObject.Results.Add(cloneresults);
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
#nullable disable
    }
}