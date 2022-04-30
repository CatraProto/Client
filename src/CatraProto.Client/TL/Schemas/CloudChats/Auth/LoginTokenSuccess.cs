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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LoginTokenSuccess : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 957176926; }

        [Newtonsoft.Json.JsonProperty("authorization")]
        public CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase Authorization { get; set; }


#nullable enable
        public LoginTokenSuccess(CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase authorization)
        {
            Authorization = authorization;

        }
#nullable disable
        internal LoginTokenSuccess()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkauthorization = writer.WriteObject(Authorization);
            if (checkauthorization.IsError)
            {
                return checkauthorization;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryauthorization = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase>();
            if (tryauthorization.IsError)
            {
                return ReadResult<IObject>.Move(tryauthorization);
            }
            Authorization = tryauthorization.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.loginTokenSuccess";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LoginTokenSuccess();
            var cloneAuthorization = (CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase?)Authorization.Clone();
            if (cloneAuthorization is null)
            {
                return null;
            }
            newClonedObject.Authorization = cloneAuthorization;
            return newClonedObject;

        }
#nullable disable
    }
}