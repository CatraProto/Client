using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1148485274; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
    }
}