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
    public partial class ExportedChatInvites : CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInvitesBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1111085620; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("invites")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase> Invites { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ExportedChatInvites(int count, List<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase> invites, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Count = count;
            Invites = invites;
            Users = users;
        }
#nullable disable
        internal ExportedChatInvites()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Count);
            var checkinvites = writer.WriteVector(Invites, false);
            if (checkinvites.IsError)
            {
                return checkinvites;
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
            var tryinvites = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryinvites.IsError)
            {
                return ReadResult<IObject>.Move(tryinvites);
            }

            Invites = tryinvites.Value;
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
            return "messages.exportedChatInvites";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ExportedChatInvites();
            newClonedObject.Count = Count;
            newClonedObject.Invites = new List<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            foreach (var invites in Invites)
            {
                var cloneinvites = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)invites.Clone();
                if (cloneinvites is null)
                {
                    return null;
                }

                newClonedObject.Invites.Add(cloneinvites);
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
            if (other is not ExportedChatInvites castedOther)
            {
                return true;
            }

            if (Count != castedOther.Count)
            {
                return true;
            }

            var invitessize = castedOther.Invites.Count;
            if (invitessize != Invites.Count)
            {
                return true;
            }

            for (var i = 0; i < invitessize; i++)
            {
                if (castedOther.Invites[i].Compare(Invites[i]))
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