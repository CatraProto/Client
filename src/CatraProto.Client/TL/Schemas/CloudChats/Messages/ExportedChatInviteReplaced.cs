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
    public partial class ExportedChatInviteReplaced : CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 572915951; }

        [Newtonsoft.Json.JsonProperty("invite")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

        [Newtonsoft.Json.JsonProperty("new_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase NewInvite { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ExportedChatInviteReplaced(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite, CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase newInvite, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Invite = invite;
            NewInvite = newInvite;
            Users = users;
        }
#nullable disable
        internal ExportedChatInviteReplaced()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkinvite = writer.WriteObject(Invite);
            if (checkinvite.IsError)
            {
                return checkinvite;
            }

            var checknewInvite = writer.WriteObject(NewInvite);
            if (checknewInvite.IsError)
            {
                return checknewInvite;
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
            var tryinvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (tryinvite.IsError)
            {
                return ReadResult<IObject>.Move(tryinvite);
            }

            Invite = tryinvite.Value;
            var trynewInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            if (trynewInvite.IsError)
            {
                return ReadResult<IObject>.Move(trynewInvite);
            }

            NewInvite = trynewInvite.Value;
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
            return "messages.exportedChatInviteReplaced";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ExportedChatInviteReplaced();
            var cloneInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)Invite.Clone();
            if (cloneInvite is null)
            {
                return null;
            }

            newClonedObject.Invite = cloneInvite;
            var cloneNewInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)NewInvite.Clone();
            if (cloneNewInvite is null)
            {
                return null;
            }

            newClonedObject.NewInvite = cloneNewInvite;
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
            if (other is not ExportedChatInviteReplaced castedOther)
            {
                return true;
            }

            if (Invite.Compare(castedOther.Invite))
            {
                return true;
            }

            if (NewInvite.Compare(castedOther.NewInvite))
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