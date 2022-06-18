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
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class WebAuthorizations : CatraProto.Client.TL.Schemas.CloudChats.Account.WebAuthorizationsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -313079300; }

        [Newtonsoft.Json.JsonProperty("authorizations")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase> Authorizations { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public WebAuthorizations(List<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase> authorizations, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Authorizations = authorizations;
            Users = users;

        }
#nullable disable
        internal WebAuthorizations()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkauthorizations = writer.WriteVector(Authorizations, false);
            if (checkauthorizations.IsError)
            {
                return checkauthorizations;
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
            var tryauthorizations = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryauthorizations.IsError)
            {
                return ReadResult<IObject>.Move(tryauthorizations);
            }
            Authorizations = tryauthorizations.Value;
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
            return "account.webAuthorizations";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebAuthorizations
            {
                Authorizations = new List<CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase>()
            };
            foreach (var authorizations in Authorizations)
            {
                var cloneauthorizations = (CatraProto.Client.TL.Schemas.CloudChats.WebAuthorizationBase?)authorizations.Clone();
                if (cloneauthorizations is null)
                {
                    return null;
                }
                newClonedObject.Authorizations.Add(cloneauthorizations);
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
            if (other is not WebAuthorizations castedOther)
            {
                return true;
            }
            var authorizationssize = castedOther.Authorizations.Count;
            if (authorizationssize != Authorizations.Count)
            {
                return true;
            }
            for (var i = 0; i < authorizationssize; i++)
            {
                if (castedOther.Authorizations[i].Compare(Authorizations[i]))
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