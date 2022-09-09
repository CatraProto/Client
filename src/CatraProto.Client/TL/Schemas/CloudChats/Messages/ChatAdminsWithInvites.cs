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
    public partial class ChatAdminsWithInvites : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatAdminsWithInvitesBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1231326505; }

        [Newtonsoft.Json.JsonProperty("admins")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase> Admins { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public ChatAdminsWithInvites(List<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase> admins, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Admins = admins;
            Users = users;
        }
#nullable disable
        internal ChatAdminsWithInvites()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkadmins = writer.WriteVector(Admins, false);
            if (checkadmins.IsError)
            {
                return checkadmins;
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
            var tryadmins = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryadmins.IsError)
            {
                return ReadResult<IObject>.Move(tryadmins);
            }

            Admins = tryadmins.Value;
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
            return "messages.chatAdminsWithInvites";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatAdminsWithInvites();
            newClonedObject.Admins = new List<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase>();
            foreach (var admins in Admins)
            {
                var cloneadmins = (CatraProto.Client.TL.Schemas.CloudChats.ChatAdminWithInvitesBase?)admins.Clone();
                if (cloneadmins is null)
                {
                    return null;
                }

                newClonedObject.Admins.Add(cloneadmins);
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
            if (other is not ChatAdminsWithInvites castedOther)
            {
                return true;
            }

            var adminssize = castedOther.Admins.Count;
            if (adminssize != Admins.Count)
            {
                return true;
            }

            for (var i = 0; i < adminssize; i++)
            {
                if (castedOther.Admins[i].Compare(Admins[i]))
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