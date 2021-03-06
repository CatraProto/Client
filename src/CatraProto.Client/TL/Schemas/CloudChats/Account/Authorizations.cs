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
    public partial class Authorizations : CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1275039392; }

        [Newtonsoft.Json.JsonProperty("authorization_ttl_days")]
        public sealed override int AuthorizationTtlDays { get; set; }

        [Newtonsoft.Json.JsonProperty("authorizations")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase> AuthorizationsField { get; set; }


#nullable enable
        public Authorizations(int authorizationTtlDays, List<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase> authorizationsField)
        {
            AuthorizationTtlDays = authorizationTtlDays;
            AuthorizationsField = authorizationsField;

        }
#nullable disable
        internal Authorizations()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(AuthorizationTtlDays);
            var checkauthorizationsField = writer.WriteVector(AuthorizationsField, false);
            if (checkauthorizationsField.IsError)
            {
                return checkauthorizationsField;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryauthorizationTtlDays = reader.ReadInt32();
            if (tryauthorizationTtlDays.IsError)
            {
                return ReadResult<IObject>.Move(tryauthorizationTtlDays);
            }
            AuthorizationTtlDays = tryauthorizationTtlDays.Value;
            var tryauthorizationsField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryauthorizationsField.IsError)
            {
                return ReadResult<IObject>.Move(tryauthorizationsField);
            }
            AuthorizationsField = tryauthorizationsField.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.authorizations";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Authorizations
            {
                AuthorizationTtlDays = AuthorizationTtlDays,
                AuthorizationsField = new List<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>()
            };
            foreach (var authorizationsField in AuthorizationsField)
            {
                var cloneauthorizationsField = (CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase?)authorizationsField.Clone();
                if (cloneauthorizationsField is null)
                {
                    return null;
                }
                newClonedObject.AuthorizationsField.Add(cloneauthorizationsField);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not Authorizations castedOther)
            {
                return true;
            }
            if (AuthorizationTtlDays != castedOther.AuthorizationTtlDays)
            {
                return true;
            }
            var authorizationsFieldsize = castedOther.AuthorizationsField.Count;
            if (authorizationsFieldsize != AuthorizationsField.Count)
            {
                return true;
            }
            for (var i = 0; i < authorizationsFieldsize; i++)
            {
                if (castedOther.AuthorizationsField[i].Compare(AuthorizationsField[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}