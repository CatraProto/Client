using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class SetAuthorizationTTL : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1081501024; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("authorization_ttl_days")]
        public int AuthorizationTtlDays { get; set; }


#nullable enable
        public SetAuthorizationTTL(int authorizationTtlDays)
        {
            AuthorizationTtlDays = authorizationTtlDays;
        }
#nullable disable

        internal SetAuthorizationTTL()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(AuthorizationTtlDays);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryauthorizationTtlDays = reader.ReadInt32();
            if (tryauthorizationTtlDays.IsError)
            {
                return ReadResult<IObject>.Move(tryauthorizationTtlDays);
            }

            AuthorizationTtlDays = tryauthorizationTtlDays.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.setAuthorizationTTL";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetAuthorizationTTL();
            newClonedObject.AuthorizationTtlDays = AuthorizationTtlDays;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetAuthorizationTTL castedOther)
            {
                return true;
            }

            if (AuthorizationTtlDays != castedOther.AuthorizationTtlDays)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}