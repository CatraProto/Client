using System;
using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class AuthorizationForm : AuthorizationFormBase
    {
        [Flags]
        public enum FlagsEnum
        {
            PrivacyPolicyUrl = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => -1389486888;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("required_types")] public override IList<SecureRequiredTypeBase> RequiredTypes { get; set; }

        [JsonProperty("values")] public override IList<SecureValueBase> Values { get; set; }

        [JsonProperty("errors")] public override IList<SecureValueErrorBase> Errors { get; set; }

        [JsonProperty("users")] public override IList<UserBase> Users { get; set; }

        [JsonProperty("privacy_policy_url")] public override string PrivacyPolicyUrl { get; set; }


        public override void UpdateFlags()
        {
            Flags = PrivacyPolicyUrl == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(RequiredTypes);
            writer.Write(Values);
            writer.Write(Errors);
            writer.Write(Users);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(PrivacyPolicyUrl);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            RequiredTypes = reader.ReadVector<SecureRequiredTypeBase>();
            Values = reader.ReadVector<SecureValueBase>();
            Errors = reader.ReadVector<SecureValueErrorBase>();
            Users = reader.ReadVector<UserBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                PrivacyPolicyUrl = reader.Read<string>();
            }
        }

        public override string ToString()
        {
            return "account.authorizationForm";
        }
    }
}