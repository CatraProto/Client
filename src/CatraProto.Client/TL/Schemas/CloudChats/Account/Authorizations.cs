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
    public partial class Authorizations : CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationsBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1275039392; }

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
            var newClonedObject = new Authorizations();
            newClonedObject.AuthorizationTtlDays = AuthorizationTtlDays;
            newClonedObject.AuthorizationsField = new List<CatraProto.Client.TL.Schemas.CloudChats.AuthorizationBase>();
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