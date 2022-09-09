using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionChatAddUser : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 365886720; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<long> Users { get; set; }


#nullable enable
        public MessageActionChatAddUser(List<long> users)
        {
            Users = users;
        }
#nullable disable
        internal MessageActionChatAddUser()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(Users, false);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryusers = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }

            Users = tryusers.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageActionChatAddUser";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionChatAddUser();
            newClonedObject.Users = new List<long>();
            foreach (var users in Users)
            {
                newClonedObject.Users.Add(users);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionChatAddUser castedOther)
            {
                return true;
            }

            var userssize = castedOther.Users.Count;
            if (userssize != Users.Count)
            {
                return true;
            }

            for (var i = 0; i < userssize; i++)
            {
                if (castedOther.Users[i] != Users[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}