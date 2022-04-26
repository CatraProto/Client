using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class AuthorizationForm : CatraProto.Client.TL.Schemas.CloudChats.Account.AuthorizationFormBase
    {
        [Flags]
        public enum FlagsEnum
        {
            PrivacyPolicyUrl = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1389486888; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("required_types")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> RequiredTypes { get; set; }

        [Newtonsoft.Json.JsonProperty("values")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }

        [Newtonsoft.Json.JsonProperty("errors")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("privacy_policy_url")]
        public sealed override string PrivacyPolicyUrl { get; set; }


#nullable enable
        public AuthorizationForm(List<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> requiredTypes, List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> values, List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> errors, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            RequiredTypes = requiredTypes;
            Values = values;
            Errors = errors;
            Users = users;

        }
#nullable disable
        internal AuthorizationForm()
        {
        }

        public override void UpdateFlags()
        {
            Flags = PrivacyPolicyUrl == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkrequiredTypes = writer.WriteVector(RequiredTypes, false);
            if (checkrequiredTypes.IsError)
            {
                return checkrequiredTypes;
            }
            var checkvalues = writer.WriteVector(Values, false);
            if (checkvalues.IsError)
            {
                return checkvalues;
            }
            var checkerrors = writer.WriteVector(Errors, false);
            if (checkerrors.IsError)
            {
                return checkerrors;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteString(PrivacyPolicyUrl);
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var tryrequiredTypes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrequiredTypes.IsError)
            {
                return ReadResult<IObject>.Move(tryrequiredTypes);
            }
            RequiredTypes = tryrequiredTypes.Value;
            var tryvalues = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryvalues.IsError)
            {
                return ReadResult<IObject>.Move(tryvalues);
            }
            Values = tryvalues.Value;
            var tryerrors = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryerrors.IsError)
            {
                return ReadResult<IObject>.Move(tryerrors);
            }
            Errors = tryerrors.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryprivacyPolicyUrl = reader.ReadString();
                if (tryprivacyPolicyUrl.IsError)
                {
                    return ReadResult<IObject>.Move(tryprivacyPolicyUrl);
                }
                PrivacyPolicyUrl = tryprivacyPolicyUrl.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.authorizationForm";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AuthorizationForm
            {
                Flags = Flags
            };
            foreach (var requiredTypes in RequiredTypes)
            {
                var clonerequiredTypes = (CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase?)requiredTypes.Clone();
                if (clonerequiredTypes is null)
                {
                    return null;
                }
                newClonedObject.RequiredTypes.Add(clonerequiredTypes);
            }
            foreach (var values in Values)
            {
                var clonevalues = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase?)values.Clone();
                if (clonevalues is null)
                {
                    return null;
                }
                newClonedObject.Values.Add(clonevalues);
            }
            foreach (var errors in Errors)
            {
                var cloneerrors = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase?)errors.Clone();
                if (cloneerrors is null)
                {
                    return null;
                }
                newClonedObject.Errors.Add(cloneerrors);
            }
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }
                newClonedObject.Users.Add(cloneusers);
            }
            newClonedObject.PrivacyPolicyUrl = PrivacyPolicyUrl;
            return newClonedObject;

        }
#nullable disable
    }
}