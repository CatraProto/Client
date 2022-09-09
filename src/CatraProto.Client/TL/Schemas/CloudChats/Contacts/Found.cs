using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Found : CatraProto.Client.TL.Schemas.CloudChats.Contacts.FoundBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1290580579; }

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
            var newClonedObject = new Found();
            newClonedObject.MyResults = new List<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
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

        public override bool Compare(IObject other)
        {
            if (other is not Found castedOther)
            {
                return true;
            }

            var myResultssize = castedOther.MyResults.Count;
            if (myResultssize != MyResults.Count)
            {
                return true;
            }

            for (var i = 0; i < myResultssize; i++)
            {
                if (castedOther.MyResults[i].Compare(MyResults[i]))
                {
                    return true;
                }
            }

            var resultssize = castedOther.Results.Count;
            if (resultssize != Results.Count)
            {
                return true;
            }

            for (var i = 0; i < resultssize; i++)
            {
                if (castedOther.Results[i].Compare(Results[i]))
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