using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class LoginTokenSuccess : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 957176926; }

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

        public override bool Compare(IObject other)
        {
            if (other is not LoginTokenSuccess castedOther)
            {
                return true;
            }

            if (Authorization.Compare(castedOther.Authorization))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}