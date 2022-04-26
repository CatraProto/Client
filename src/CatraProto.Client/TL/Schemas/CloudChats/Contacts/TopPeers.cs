using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class TopPeers : CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1891070632; }

        [Newtonsoft.Json.JsonProperty("categories")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase> Categories { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public TopPeers(List<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase> categories, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Categories = categories;
            Chats = chats;
            Users = users;

        }
#nullable disable
        internal TopPeers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcategories = writer.WriteVector(Categories, false);
            if (checkcategories.IsError)
            {
                return checkcategories;
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
            var trycategories = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycategories.IsError)
            {
                return ReadResult<IObject>.Move(trycategories);
            }
            Categories = trycategories.Value;
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
            return "contacts.topPeers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TopPeers();
            foreach (var categories in Categories)
            {
                var clonecategories = (CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase?)categories.Clone();
                if (clonecategories is null)
                {
                    return null;
                }
                newClonedObject.Categories.Add(clonecategories);
            }
            foreach (var chats in Chats)
            {
                var clonechats = (CatraProto.Client.TL.Schemas.CloudChats.ChatBase?)chats.Clone();
                if (clonechats is null)
                {
                    return null;
                }
                newClonedObject.Chats.Add(clonechats);
            }
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