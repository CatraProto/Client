using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ChatInviteImporters : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatInviteImportersBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2118733814; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("importers")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase> Importers { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ChatInviteImporters(int count, List<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase> importers, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            Importers = importers;
            Users = users;
        }
#nullable disable
        internal ChatInviteImporters()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checkimporters = writer.WriteVector(Importers, false);
            if (checkimporters.IsError)
            {
                return checkimporters;
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
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }

            Count = trycount.Value;
            var tryimporters = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryimporters.IsError)
            {
                return ReadResult<IObject>.Move(tryimporters);
            }

            Importers = tryimporters.Value;
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
            return "messages.chatInviteImporters";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatInviteImporters();
            newClonedObject.Count = Count;
            newClonedObject.Importers = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase>();
            foreach (var importers in Importers)
            {
                var cloneimporters = (CatraProto.Client.TL.Schemas.CloudChats.ChatInviteImporterBase?)importers.Clone();
                if (cloneimporters is null)
                {
                    return null;
                }

                newClonedObject.Importers.Add(cloneimporters);
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
            if (other is not ChatInviteImporters castedOther)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            var importerssize = castedOther.Importers.Count;
            if (importerssize != Importers.Count)
            {
                return true;
            }

            for (var i = 0; i < importerssize; i++)
            {
                if (castedOther.Importers[i].Compare(Importers[i]))
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