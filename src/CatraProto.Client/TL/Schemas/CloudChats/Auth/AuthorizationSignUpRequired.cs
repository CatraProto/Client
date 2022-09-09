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
    public partial class AuthorizationSignUpRequired : CatraProto.Client.TL.Schemas.CloudChats.Auth.AuthorizationBase
    {
        [Flags]
        public enum FlagsEnum
        {
            TermsOfService = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1148485274; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("terms_of_service")]
        public CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase TermsOfService { get; set; }


        public AuthorizationSignUpRequired()
        {
        }

        public override void UpdateFlags()
        {
            Flags = TermsOfService == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checktermsOfService = writer.WriteObject(TermsOfService);
                if (checktermsOfService.IsError)
                {
                    return checktermsOfService;
                }
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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trytermsOfService = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase>();
                if (trytermsOfService.IsError)
                {
                    return ReadResult<IObject>.Move(trytermsOfService);
                }

                TermsOfService = trytermsOfService.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.authorizationSignUpRequired";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new AuthorizationSignUpRequired();
            newClonedObject.Flags = Flags;
            if (TermsOfService is not null)
            {
                var cloneTermsOfService = (CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceBase?)TermsOfService.Clone();
                if (cloneTermsOfService is null)
                {
                    return null;
                }

                newClonedObject.TermsOfService = cloneTermsOfService;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not AuthorizationSignUpRequired castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (TermsOfService is null && castedOther.TermsOfService is not null || TermsOfService is not null && castedOther.TermsOfService is null)
            {
                return true;
            }

            if (TermsOfService is not null && castedOther.TermsOfService is not null && TermsOfService.Compare(castedOther.TermsOfService))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}